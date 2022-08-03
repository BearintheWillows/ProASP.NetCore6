using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

public class EditorModel : PageModel
{
	private ApplicationDbContext context;
	public  Product?    Product { get; set; }
	public EditorModel(ApplicationDbContext ctx) {
		context = ctx;
	}
	public async Task OnGetAsync(long id) {
		Product = await context.Products.FindAsync(id);
	}
	public async Task<IActionResult> OnPostAsync(long id, decimal price) {
		Product? p = await context.Products.FindAsync(id);
		if (p != null) {
			p.Price = price;
		}
		await context.SaveChangesAsync();
		return RedirectToPage();
	}
}