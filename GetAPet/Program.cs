using GetAPet.Data;
using GetAPet.Models;
using GetAPet.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>( 
	options => options.UseSqlServer( builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddScoped<IAppRepository, EFAppRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( !app.Environment.IsDevelopment() )
{
	app.UseExceptionHandler( "/Home/Error" );

	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseRouting();


app.MapControllerRoute("pagination", "Pets/Page-{currentPage}", 
                       new { Controller = "Home", action = "Index" });

app.MapDefaultControllerRoute();
SeedData.EnsurePopulated(app);

app.Run();