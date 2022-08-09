namespace WebApp.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
	public IActionResult Index()
	{
		return View("Message", "Index action of Home Controller");
	}
}