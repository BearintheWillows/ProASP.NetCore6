using Platform;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();

app.MapGet( "population/{city}", Capital.Endpoint) ;

app.Run();