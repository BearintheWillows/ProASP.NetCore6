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
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.MapControllerRoute( "forms", "controllers/{controller=Home}/{action=Index}/{id?}" );
app.MapRazorPages();
var context = app.Services.CreateScope().ServiceProvider
                 .GetRequiredService<ApplicationDbContext>();
SeedData.SeedDatabase(context);
app.Run();