// using Microsoft.AspNetCore.Mvc.RazorPages;
//
// namespace WebApp.Pages;
//
// using Models;
// using WebApp.Data;
//
// public class DataPageModel : PageModel
// {
// 	private ApplicationDbContext context;
// 	public IEnumerable<Category> Categories { get; set; }
// 		= Enumerable.Empty<Category>();
// 	public DataPageModel(ApplicationDbContext ctx) {
// 		context = ctx;
// 	}
// 	public void OnGet() {
// 		Categories = context.Categories;
// 	}
// }