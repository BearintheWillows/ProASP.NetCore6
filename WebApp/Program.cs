using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

var builder = WebApplication.CreateBuilder( args );


builder.Services.AddDbContext<ApplicationDbContext>( opts =>
	{
		opts.UseSqlServer( builder.Configuration[ "ConnectionStrings:ProductConnection" ] );
		opts.EnableSensitiveDataLogging( true );
	}
);

var app = builder.Build();

app.MapGet( "/", () => "Hello World!" );

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

SeedData.SeedDatabase( context );

app.Run();