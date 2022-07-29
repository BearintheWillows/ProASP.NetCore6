namespace Platform;

public class Capital
{
	private RequestDelegate? next;
	
	public Capital(){}

	public Capital(RequestDelegate? next)
	{
		this.next = next;
	}
	
	public static async Task Endpoint(HttpContext context)
	{
		string? capital = null;
		string? country = context.Request.RouteValues["country"] as string;
		switch (( country ?? "").ToLower() )
			{
				case "uk":
					capital = "London";
					break;
				case "france":
					capital = "Paris";
					break;
				case "monaco":
					LinkGenerator? generator = context.RequestServices.GetService<LinkGenerator>();
					string? url = generator?.GetPathByRouteValues( context, "poplation", new { city = country } );
					if ( url !=null )
					{
						context.Response.Redirect( url );
						return;
					}

					break;
			}
			if ( capital != null )
			{
				await context.Response.WriteAsync($"{country}'s capital is {capital}");
			} else
			{
				context.Response.StatusCode = StatusCodes.Status404NotFound;
			}
	}
}