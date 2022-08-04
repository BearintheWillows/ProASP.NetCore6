using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using WebApp.Data;
using WebApp.Middleware;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(opts => {
	opts.UseSqlServer(builder.Configuration[
		                  "ConnectionStrings:ProductConnection"]);
	opts.EnableSensitiveDataLogging(true);
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession( opts =>
	{
		opts.Cookie.IsEssential = true;
	}
);

builder.Services.Configure<RazorPagesOptions>( opts =>
	{
		opts.Conventions.AddPageRoute( "/Index", "/extra/page/{id:long}" );
	}
);

builder.Services.AddSingleton<CitiesData>();

var app = builder.Build();
app.UseStaticFiles();

app.UseSession();

app.MapControllers();

app.MapDefaultControllerRoute();
app.MapRazorPages();

var context = app.Services.CreateScope().ServiceProvider
                 .GetRequiredService<ApplicationDbContext>();
SeedData.SeedDatabase(context);

app.Run();