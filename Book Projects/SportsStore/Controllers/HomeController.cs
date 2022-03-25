using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers;

public class HomeController : Controller
{
	// GET
	public IActionResult Index() => View();
}