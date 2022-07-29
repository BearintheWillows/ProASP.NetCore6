namespace Platform;

using Microsoft.Extensions.Options;

public class QueryStringMiddleWare
{
	private RequestDelegate? _next;

	public QueryStringMiddleWare()
	{
		//do nothing. Terminal Middleware
	}

	public QueryStringMiddleWare(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		if ( context.Request.Method == HttpMethods.Get 
		    && context.Request.Query["custom"] == "true")
		{
			if ( !context.Response.HasStarted )
			{
				context.Response.ContentType = "text/plain";
			}

			await context.Response.WriteAsync( "Class-based Middleware \n" );
		}

		if ( _next != null )
		{
			await _next( context );
		}
		
	}
}

public class LocationMiddleware
{
	private RequestDelegate next;
	private MessageOptions  _options;
	
	public LocationMiddleware(RequestDelegate next, IOptions<MessageOptions> options)
	{
		this.next = next;
		_options = options.Value;
	}

	public async Task Invoke(HttpContext context)
	{
		if ( context.Request.Path == "/location" )
		{
			await context.Response.WriteAsync( $"{_options.CityName}, {_options.CountryName}" );
		} else
		{
			await next( context );
		}
	}
}