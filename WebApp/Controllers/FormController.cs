namespace WebApp.Controllers;

using System.Globalization;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

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
	public IActionResult SubmitForm([Bind("Name", "Category")] Product product)
	{
		TempData["name"] = product.Name;
		TempData[ "price" ] = product.Price.ToString();
		TempData[ "category name" ] = product.Category?.Name;
		return RedirectToAction(nameof(Results));
	}
	public IActionResult Results()
	{
		return View();
	}
}