using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using Microsoft.AspNetCore.Mvc;

public class BindingsModel : PageModel
{
	[BindProperty( Name = "Data" )]
	public string[] Data { get; set; } = Array.Empty<string>();
}