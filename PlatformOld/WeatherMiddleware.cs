namespace Platform;

using Services.Interfaces;

public class WeatherMiddleware
{
	private RequestDelegate next;
	/// private IResponseFormatter _formatter;

	public WeatherMiddleware(RequestDelegate next, IResponseFormatter formatter)
	{
		this.next = next;
		//this._formatter = formatter;
	}

	public async Task Invoke(HttpContext context, IResponseFormatter _formatter)
	{
		if ( context.Request.Path == "/middleware/class" )
		{
			await _formatter.Format(context, "Hello from the WeatherMiddleware class!");
		} else
		{
			await next(context);
		}
	}
}