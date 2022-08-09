using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

public class DeleteModel: EditorPageModel {
	public DeleteModel(ApplicationDbContext dbContext): base(dbContext) {}
	public async Task OnGetAsync(long id) {
		ViewModel = ViewModelFactory.Delete(
			await DataContext.Products.FindAsync(id) ?? new Product(),
			Categories, Suppliers);
	}
	public async Task<IActionResult> OnPostAsync([FromForm] Product product) {
		DataContext.Products.Remove(product);
		await DataContext.SaveChangesAsync();
		return RedirectToPage(nameof(Index));
	}
}