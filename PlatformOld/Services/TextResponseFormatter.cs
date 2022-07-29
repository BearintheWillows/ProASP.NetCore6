namespace Platform.Services;

using Interfaces;

public class TextResponseFormatter : IResponseFormatter
{
	private        int                    _responseCounter = 0;
	private static TextResponseFormatter? shared;

	public async Task Format(HttpContext context, string content)
	{
		await context.Response.WriteAsync( $"Response {++_responseCounter}:\n{content}" );
	}

	//Singleton Pattern
	public static TextResponseFormatter Singleton
	{
		get
		{
			if ( shared == null )
			{
				shared = new TextResponseFormatter();
			}

			return shared;
		}
	}
}