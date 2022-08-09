using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using System.Text.Json;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

public class EditModel: EditorPageModel {
	public EditModel(ApplicationDbContext dbContext): base(dbContext) {}
	public async Task OnGetAsync(long id) {
		Product? p = TempData.ContainsKey("product")
			? JsonSerializer.Deserialize<Product>(
				(TempData["product"] as string)!)
			: await this.DataContext.Products.FindAsync(id);
		ViewModel = ViewModelFactory.Edit(p ?? new Product(),
		                                  Categories, Suppliers);
	}
	public async Task<IActionResult> OnPostAsync([FromForm] Product product)
	{
		await CheckNewCategory( product );
		if (ModelState.IsValid) {
			product.Category = default;
			product.Supplier = default;
			DataContext.Products.Update(product);
			await DataContext.SaveChangesAsync();
			return RedirectToPage(nameof(Index));
		}
		ViewModel = ViewModelFactory.Edit(product, Categories, Suppliers);
		return Page();
	}
}