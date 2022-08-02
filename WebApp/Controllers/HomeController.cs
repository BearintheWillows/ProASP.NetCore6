namespace WebApp.Controllers;

using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

public class HomeController : Controller
{
	private ApplicationDbContext _context;

	public HomeController(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IActionResult> Index(long id = 1)
	{
		Product? prod = await _context.Products.FindAsync( id );
		if ( prod?.CategoryId == 1 )
		{
			return View( "Watersports", prod );
		} else
		{
			return View( prod );
		}
	}
	
	public IActionResult Common()
	{
		return View();
	}

	public IActionResult List()
	{
		return View( _context.Products );
	}
}