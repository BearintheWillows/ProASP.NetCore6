using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

public class FormHandlerModel : PageModel
{
	private ApplicationDbContext _context;
	public FormHandlerModel(ApplicationDbContext dbContext) {
		_context = dbContext;
	}

	[BindProperty]
	public Product  Product { get; set; } = new();
	public async Task OnGetAsync(long id = 1)
	{
		Product = await _context.Products.Include( p => p.Category )
		                        .Include( p => p.Supplier ).FirstAsync( p => p.ProductId == id );
	}
	public IActionResult OnPost() {
		TempData["product"] = System.Text.Json.JsonSerializer.Serialize(Product);
		return RedirectToPage("FormResults");
	}
}