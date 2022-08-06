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
	public Product? Product { get; set; }
	public async Task OnGetAsync(long id = 1)
	{
		Product = await _context.Products.Include( p => p.Category )
		                        .Include( p => p.Supplier ).FirstAsync( p => p.ProductId == id );
	}
	public IActionResult OnPost() {
		foreach (string key in Request.Form.Keys
		                              .Where(k => !k.StartsWith("_"))) {
			TempData[key] = string.Join(", ", Request.Form[key]);
		}
		return RedirectToPage("FormResults");
	}
}