using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

public class IndexModel : PageModel
{
	private ApplicationDbContext context;
	public  Product?    Product { get; set; }
	public IndexModel(ApplicationDbContext ctx) {
		context = ctx;
	}
	public async Task<IActionResult> OnGetAsync(long id = 1) {
		Product = await context.Products.FindAsync(id);
		if ( Product == null )
		{
			return RedirectToPage( "NotFound" );
		}

		return Page();
	}
}