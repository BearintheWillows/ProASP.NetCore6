using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
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
builder.Services.AddControllers().AddNewtonsoftJson().
        AddXmlDataContractSerializerFormatters();
builder.Services.Configure<MvcNewtonsoftJsonOptions>(opts => {
	opts.SerializerSettings.NullValueHandling
		= Newtonsoft.Json.NullValueHandling.Ignore;
});
builder.Services.Configure<MvcOptions>(opts => {
	opts.RespectBrowserAcceptHeader = true;
	opts.ReturnHttpNotAcceptable = true;
});
builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApp", Version = "v1" });
});
var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.UseSwagger();
app.UseSwaggerUI(options => {
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApp");
});
var context = app.Services.CreateScope().ServiceProvider
                 .GetRequiredService<ApplicationDbContext>();
SeedData.SeedDatabase(context);
app.Run();