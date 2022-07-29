namespace Platform.Services.Interfaces;

public interface IResponseFormatter
{
	Task Format(HttpContext context, string content);
}