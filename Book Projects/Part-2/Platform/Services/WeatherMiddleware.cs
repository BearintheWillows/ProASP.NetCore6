using System.Runtime.Serialization;

namespace Platform.Services;

public class WeatherMiddleware
{
	private RequestDelegate    _next;
	private IResponseFormatter _formatter;

	public WeatherMiddleware( RequestDelegate nextDelegate, IResponseFormatter responseFormatter )
	{
		_next     = nextDelegate;
		_formatter = responseFormatter;
	}

	public async Task Invoke( HttpContext context )
	{
		if ( context.Request.Path == "/middleware/class" )
		{
			await _formatter.Format( context, "Laaaandaaaan" );
		}
		else
		{
			await _next( context );
		}
	}
}