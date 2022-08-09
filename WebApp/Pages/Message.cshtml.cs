using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class MessageModel : PageModel
{
	public Object Message { get; set; } = "This is the Message Razor Page";
}