using Microsoft.Extensions.Options;
using Platform;
using Platform.Services;
using Platform.Services.Extensions;
using Platform.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IResponseFormatter, GuidService>();

var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();

app.MapGet("middleware/function", async (HttpContext context, IResponseFormatter formatter) => {
	await formatter.Format(context, "Middleware Function: It is snowing in Chicago");
});

//app.MapGet( "endpoint/class" );
app.MapEndpoint<WeatherEndpoint>( "endpoint/class"  );

app.MapGet("endpoint/function", async (HttpContext context, IResponseFormatter formatter) => {
	await formatter.Format(context, "Endpoint Function: It is sunny in LA");
});

app.Run();