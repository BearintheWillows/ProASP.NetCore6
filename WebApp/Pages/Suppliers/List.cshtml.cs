using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Suppliers;

using Data;

public class ListModel : PageModel
{
	private ApplicationDbContext         context;
	public  IEnumerable<string> Suppliers { get; set; } = Enumerable.Empty<string>();
	public ListModel(ApplicationDbContext ctx) {
		context = ctx;
	}
	public void OnGet() {
		Suppliers = context.Suppliers.Select(s => s.Name);
	}
}