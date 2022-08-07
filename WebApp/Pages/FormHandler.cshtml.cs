using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Models;

public class FormHandlerModel : PageModel
{
	private ApplicationDbContext _context;

	public FormHandlerModel(ApplicationDbContext dbContext)
	{
		_context = dbContext;
	}

	[BindProperty]
	public Product Product { get; set; } = new();

	public async Task OnGetAsync(long id = 1)
	{
		Product = await _context.Products.FirstAsync( p => p.ProductId == id );
	}

	public IActionResult OnPost()
	{
		if ( ModelState.GetValidationState( "Product.Price" )
		 == ModelValidationState.Valid && Product.Price < 1 )
		{
			ModelState.AddModelError( "Product.Price", "Enter a positive price" );
		}

		if ( ModelState.GetValidationState( "Product.Name" )
		  == ModelValidationState.Valid
		  && ModelState.GetValidationState( "Product.Price" )
		  == ModelValidationState.Valid
		  && Product.Name.ToLower().StartsWith( "small" )
		  && Product.Price > 100 )
		{
			ModelState.AddModelError( "",
			                          "Small products cannot cost more than $100"
			);
		}

		if ( ModelState.GetValidationState( "Product.CategoryId" )
		  == ModelValidationState.Valid &&
		     !_context.Categories.Any( c => c.CategoryId == Product.CategoryId ) )
		{
			ModelState.AddModelError( "Product.CategoryId",
			                          "Enter an existing category ID"
			);
		}

		if ( ModelState.GetValidationState( "Product.SupplierId" )
		  == ModelValidationState.Valid &&
		     !_context.Suppliers.Any( s => s.SupplierId == Product.SupplierId ) )
		{
			ModelState.AddModelError( "Product.SupplierId",
			                          "Enter an existing supplier ID"
			);
		}

		if ( ModelState.IsValid )
		{
			TempData[ "name" ] = Product.Name;
			TempData[ "price" ] = Product.Price.ToString();
			TempData[ "categoryId" ] = Product.CategoryId.ToString();
			TempData[ "supplierId" ] = Product.SupplierId.ToString();
			return RedirectToPage( "FormResults" );
		} else
		{
			return Page();
		}
	}
}