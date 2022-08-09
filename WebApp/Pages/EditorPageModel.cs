namespace WebApp.Pages;

using Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

public class EditorPageModel : PageModel {
	public EditorPageModel(ApplicationDbContext dbContext) {
		DataContext = dbContext;
	}
	public ApplicationDbContext          DataContext { get; set; }
	public IEnumerable<Category> Categories  => DataContext.Categories;
	public IEnumerable<Supplier> Suppliers   => DataContext.Suppliers;
	public ProductViewModel?     ViewModel   { get; set; }
	
	protected async Task CheckNewCategory(Product product) {
		if (product.CategoryId == -1
		 && !string.IsNullOrEmpty(product.Category?.Name)) {
			DataContext.Categories.Add(product.Category);
			await DataContext.SaveChangesAsync();
			product.CategoryId = product.Category.CategoryId;
			ModelState.Clear();
			TryValidateModel(product);
		}
	}
}