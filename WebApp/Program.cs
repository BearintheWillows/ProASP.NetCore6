using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(opts => {
	opts.UseSqlServer(builder.Configuration[
		                  "ConnectionStrings:ProductConnection"]);
	opts.EnableSensitiveDataLogging(true);
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddSingleton<CitiesData>();

builder.Services.Configure<AntiforgeryOptions>( opts =>
	{
		opts.HeaderName = "X-XSRF-TOKEN";
	}
);

builder.Services.Configure<MvcOptions>( opts => opts.ModelBindingMessageProvider
                                                    .SetValueMustNotBeNullAccessor( value => "Please enter a Value" )
);

var app = builder.Build();
app.UseStaticFiles();

IAntiforgery antiforgery = app.Services.GetRequiredService<IAntiforgery>();
app.Use(async (context, next) => {
	if (!context.Request.Path.StartsWithSegments("/api")) {
		string? token = antiforgery.GetAndStoreTokens(context).RequestToken;
		if (token != null) {
			context.Response.Cookies.Append("XSRF-TOKEN",
			                                token,
			                                new CookieOptions { HttpOnly = false });
		}
	}
	await next();
});

// app.MapControllers();

// app.MapDefaultControllerRoute();

app.MapControllerRoute( "forms", "controllers/{controller=Home}/{action=Index}/{id?}" );

app.MapRazorPages();

var context = app.Services.CreateScope().ServiceProvider
                 .GetRequiredService<ApplicationDbContext>();
SeedData.SeedDatabase(context);

app.Run();