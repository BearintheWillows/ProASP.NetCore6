namespace WebApp.Middleware;

using Data;

public class TestMiddleware
{
	private RequestDelegate _nextDelegate;

	public TestMiddleware(RequestDelegate nextDelegate)
	{
		_nextDelegate = nextDelegate;
	}
	
	public async Task Invoke(HttpContext context, ApplicationDbContext dbContext)
	{
		if ( context.Request.Path == "/test" )
		{
			await context.Response.WriteAsync( $"There are {dbContext.Products.Count()} products\n" );
			await context.Response.WriteAsync( $"There are {dbContext.Categories.Count()} categories\n" );
			await context.Response.WriteAsync( $"There are {dbContext.Suppliers.Count()} suppliers\n" );
		} else
		{
			await _nextDelegate(context);
		}
	}
}