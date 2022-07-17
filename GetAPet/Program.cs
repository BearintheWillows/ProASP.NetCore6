using GetAPet.Data;
using GetAPet.Models;
using GetAPet.Models.Repository;
using Microsoft.AspNetCore.Mvc;
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

// /Dog/Page{currentPage} - Lists the specified page, showing items from the "Dog" category
app.MapControllerRoute( "speciesPage", "{species}/Page{currentPage:int}",
                        new {Controller = "Home", action = "Index"});
// /Page{currentPage} - Lists the specified page, showing items from all categories
app.MapControllerRoute("page", "Page{currentPage:int}", 
					   new { Controller = "Home", action = "Index", currentPage = 1 });
// /Dog - Lists first page of products for the "Dog" category
app.MapControllerRoute( "species", "{species}",
                        new { Controller = "Home", action = "Index", currentPage = 1 } );
// / or /Index - Lists first page of products for all categories
app.MapControllerRoute("pagination", "Pets/Page{currentPage}", 
                       new { Controller = "Home", action = "Index", currentPage = 1 });

app.MapDefaultControllerRoute();
SeedData.EnsurePopulated(app);

app.Run();