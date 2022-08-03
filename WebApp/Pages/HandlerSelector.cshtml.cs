using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;

public class HandlerSelectorModel : PageModel
{
	private ApplicationDbContext context;
	public  Product?    Product { get; set; }
	public HandlerSelectorModel(ApplicationDbContext ctx) {
		context = ctx;
	}
	public async Task OnGetAsync(long id = 1) {
		Product = await context.Products.FindAsync(id);
	}
	public async Task OnGetRelatedAsync(long id = 1) {
		Product = await context.Products
		                       .Include(p => p.Supplier)
		                       .Include(p => p.Category)
		                       .FirstOrDefaultAsync(p => p.ProductId == id);
		if (Product != null && Product.Supplier != null) {
			Product.Supplier.Products = null;
		}
		if (Product != null && Product.Category != null) {
			Product.Category.Products = null;
		}
	}
}