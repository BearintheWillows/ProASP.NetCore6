namespace Platform;

using Services.Interfaces;

public class WeatherMiddleware
{
	private RequestDelegate next;
	/// private IResponseFormatter _formatter;

	public WeatherMiddleware(RequestDelegate next)
	{
		this.next = next;
		//this._formatter = formatter;
	}

	public async Task Invoke(HttpContext context, 
	                         IResponseFormatter _formatter1, 
	                         IResponseFormatter _formatter2, 
	                         IResponseFormatter _formatter3)
	{
		if ( context.Request.Path == "/middleware/class" )
		{
			await _formatter1.Format( context, string.Empty );
			await _formatter2.Format( context, string.Empty );
			await _formatter3.Format( context, string.Empty );
		} else
		{
			await next(context);
		}
	}
}