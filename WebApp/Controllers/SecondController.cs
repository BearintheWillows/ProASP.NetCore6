namespace WebApp.Controllers;

using Microsoft.AspNetCore.Mvc;

public class SecondController : Controller
{
	public IActionResult Index()
	{
		return View( "Common" );
	}
}