using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Infrastructure;
using SportsStore.Models;

namespace SportsStore.Pages;

public class CartModel : PageModel
{
	private IStoreRepository _repository;

	public Cart?  Cart      { get; set; }
	public string ReturnUrl { get; set; } = "/";

	public CartModel( IStoreRepository repo, Cart cartService )
	{
		_repository = repo;
		Cart        = cartService;
	}

	public void OnGet( string returnUrl ) => ReturnUrl = returnUrl ?? "/";

	//Cart      = HttpContext.Session.GetJson<Cart>( "Cart" ) ?? new Cart();
	public IActionResult OnPost( long productId, string returnUrl )
	{
		Product? product = _repository.Products
		                              .FirstOrDefault( p => p.ProductID == productId );
		if ( product != null )
		{
			Cart.AddItem( product, 1 );
			
		}

		return RedirectToPage( new { returnUrl } );
	}
}