using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using System.Text.Json;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

public class SupplierPageModel: PageModel {
	private ApplicationDbContext context;
	public SupplierPageModel(ApplicationDbContext dbContext) {
		context = dbContext;
	}
	[BindProperty]
	public Supplier? Supplier { get; set; }
	public string? ReturnPage { get; set; }
	public string? ProductId  { get; set; }
	public void OnGet([FromQuery(Name="Product")] Product product,
	                  string                              returnPage) {
		TempData["product"] = Serialize(product);
		TempData["returnAction"] = ReturnPage = returnPage;
		TempData["productId"] = ProductId = product.ProductId.ToString();
	}
	public async Task<IActionResult> OnPostAsync() {
		if (ModelState.IsValid && Supplier != null) {
			context.Suppliers.Add(Supplier);
			await context.SaveChangesAsync();
			Product? product = Deserialize(TempData["product"] as string);
			if (product != null) {
				product.SupplierId = Supplier.SupplierId;
				TempData["product"] = Serialize(product);
				string? id = TempData["productId"] as string;
				return RedirectToPage(TempData["returnAction"] as string,
				                      new { id = id });
			}
		}
		return Page();
	}
	private string Serialize(Product p) => JsonSerializer.Serialize(p);
	private Product? Deserialize(string? json) =>
		json == null ? null : JsonSerializer.Deserialize<Product>(json);
}