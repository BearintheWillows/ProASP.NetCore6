namespace WebApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

[AutoValidateAntiforgeryToken]
	public class FormController : Controller {
		private ApplicationDbContext _context;
		public FormController(ApplicationDbContext dbContext) {
			_context = dbContext;
		}
		public async Task<IActionResult> Index(long? id) {
			return View("Form", await _context.Products
			                                 .FirstOrDefaultAsync(p => id == null || p.ProductId == id));
		}
		[HttpPost]
		public IActionResult SubmitForm(Product product) {
			
			if ( ModelState.IsValid )
			{
				TempData[ "name" ] = product.Name;
				TempData[ "price" ] = product.Price.ToString();
				TempData[ "categoryId" ] = product.CategoryId.ToString();
				TempData[ "supplierId" ] = product.SupplierId.ToString();
				return RedirectToAction( nameof(Results) );
			} else
			{
				return View( "Form" );
			}
		}
		public IActionResult Results() {
			return View(TempData);
		}
	}