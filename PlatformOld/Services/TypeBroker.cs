namespace Platform.Services;

using Interfaces;

public static class TypeBroker
{
	private static IResponseFormatter _formatter = new HtmlResponseFormatter();
	
	public static IResponseFormatter Formatter => _formatter;
}