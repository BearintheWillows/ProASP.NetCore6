using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;

public class DetailsModel: EditorPageModel {
	public DetailsModel(ApplicationDbContext dbContext): base(dbContext) {}
	public async Task OnGetAsync(long id) {
		Product? p = await DataContext.Products.
		                               Include(p => p.Category).Include(p => p.Supplier)
		                              .FirstOrDefaultAsync(p => p.ProductId == id);
		ViewModel = ViewModelFactory.Details(p ?? new Product());
	}
}