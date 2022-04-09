using System.Reflection

namespace Platform.Services;

public static class EndPointExtensions
{
	public static void MapWeather( this IEndpointRouteBuilder app, string path )
	{
		IResponseFormatter formatter = app.ServiceProvider.GetRequiredService<IResponseFormatter>();
		app.MapGet( path, context => WeatherEndpoint
			                   .Endpoint( context, formatter ) );
	}
}