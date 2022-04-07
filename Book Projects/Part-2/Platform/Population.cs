namespace Platform;

public class Population
{

	public static async Task Endpoint( HttpContext context )
	{
		string? city = context.Request.RouteValues[ "city" ] as string ?? "london";
		int?    pop  = null;
		{
			pop = (city).ToLower() switch
			{
				"london" => 8_000_000,
				"paris"  => 2_000_000,
				"monaco" => 40_000,
				_        => null
			};

			if ( pop.HasValue )
			{
				await context.Response.WriteAsync( $"{city} has {pop} inhabitants" );
				
			}
			else
			{
				context.Response.StatusCode = StatusCodes.Status404NotFound;
			}
		}
		
	}
	
}