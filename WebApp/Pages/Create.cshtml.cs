using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using System.Text.Json;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

public class CreateModel: EditorPageModel {
	public CreateModel(ApplicationDbContext dbContext): base(dbContext) {}
	public void OnGet() {
		Product p = TempData.ContainsKey("product")
			? JsonSerializer.
				Deserialize<Product>((TempData["product"] as string)!)!
			: new Product();
		ViewModel = ViewModelFactory.Create(p, Categories, Suppliers);
	}
	public async Task<IActionResult> OnPostAsync([FromForm] Product product)
	{
		await CheckNewCategory( product );
		if (ModelState.IsValid) {
			product.ProductId = default;
			product.Category = default;
			product.Supplier = default;
			DataContext.Products.Add(product);
			await DataContext.SaveChangesAsync();
			return RedirectToPage(nameof(Index));
		}
		ViewModel = ViewModelFactory.Create(product, Categories, Suppliers);
		return Page();
	}
}