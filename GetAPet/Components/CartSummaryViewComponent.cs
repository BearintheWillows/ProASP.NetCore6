namespace GetAPet.Components;

using Microsoft.AspNetCore.Mvc;
using Models;
using Pages;

public class CartSummaryViewComponent : ViewComponent
{
	private DonationCart _cart;
	public CartSummaryViewComponent(DonationCart cartService)
	{
		_cart = cartService;
	}
	public IViewComponentResult Invoke()
		{
			return View(_cart);
		}
	}