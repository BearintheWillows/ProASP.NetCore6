using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;

public class IndexModel: PageModel {
	private ApplicationDbContext context;
	public IndexModel(ApplicationDbContext dbContext) {
		context = dbContext;
	}
	public IEnumerable<Product> Products { get; set; }
		= Enumerable.Empty<Product>();
	public void OnGetAsync(long id = 1) {
		Products = context.Products
		                  .Include(p => p.Category).Include(p => p.Supplier);
	}
}