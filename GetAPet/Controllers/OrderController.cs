namespace GetAPet.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Repository;

public class OrderController : Controller
{
	private IOrderRepository _repository;
	private DonationCart _cart;

	public OrderController(IOrderRepository repository, DonationCart cart)
	{
		_repository = repository;
		_cart = cart;
	}

	public  ViewResult       Checkout() => View(new Order());

	[HttpPost]
	public IActionResult Checkout(Order order)
	{
		if ( _cart.Lines.Count() == 0 )
		{
			ModelState.AddModelError( "", "Cart is empty!" );
		}

		if ( ModelState.IsValid )
		{
			order.Lines = _cart.Lines.ToArray();
			_repository.SaveOrder(order);
			_cart.Clear();
			return RedirectToPage( "/Completed", new { orderId = order.OrderID } );
		} 
		else
		{
			return View();
		}
	}
}