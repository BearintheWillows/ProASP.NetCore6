using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using Data;
using Models;

public class NotFoundModel : PageModel
{
	private ApplicationDbContext context;
		public IEnumerable<Product> Products { get; set; }
			= Enumerable.Empty<Product>();
		public NotFoundModel(ApplicationDbContext ctx) {
			context = ctx;
		}
		public void OnGetAsync(long id = 1) {
			Products = context.Products;
		}
}