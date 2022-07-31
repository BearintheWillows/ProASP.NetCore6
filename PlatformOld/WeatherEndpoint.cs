namespace Platform;

using Services.Interfaces;

public class WeatherEndpoint
{
	//private IResponseFormatter _formatter;

	/*public WeatherEndpoint(IResponseFormatter formatter)
	{
		_formatter = formatter;
	}*/

	public  async Task Endpoint(HttpContext context, IResponseFormatter _formatter)
	{
		
		await _formatter.Format( context, "Endpoint Class: It is cloudy in Milan!" );
	}
}