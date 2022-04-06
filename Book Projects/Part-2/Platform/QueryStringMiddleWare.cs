namespace Platform;

public class QueryStringMiddleWare
{
	private RequestDelegate _next;

	public QueryStringMiddleWare( RequestDelegate nextDelegate ) { _next = nextDelegate; }

	public async Task Invoke( HttpContext context )
	{
		if ( context.Request.Method == HttpMethods.Get
		  && context.Request.Query[ "custom" ] == true )
		{
			if ( !context.Response.HasStarted )
			{
				context.Response.ContentType = "text/plain";
			}
			await context.Response.WriteAsync( "Class-Based Middleware \n" );
		}

		await _next( context );
	}
}