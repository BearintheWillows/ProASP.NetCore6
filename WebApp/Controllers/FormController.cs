namespace WebApp.Controllers;

using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
[AutoValidateAntiforgeryToken]
public class FormController : Controller
{
	private ApplicationDbContext _context;
	
	public FormController(ApplicationDbContext context)
	{
		_context = context;
	}
	
	public async Task<IActionResult> Index(long id = 1)
	{
		ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
		return View("Form", await _context.Products.Include( p => p.Category )
		                                  .Include( p => p.Supplier )
		                                  .FirstAsync( p => p.ProductId == id ));
	}

	[HttpPost]
	public IActionResult SubmitForm()
	{
		foreach ( string key in Request.Form.Keys)
		{
			TempData[key] = string.Join(", ", Request.Form[key] );
		}
		return RedirectToAction(nameof(Results));
	}
	public IActionResult Results()
	{
		return View();
	}
}