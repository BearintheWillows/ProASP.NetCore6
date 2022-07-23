namespace GetAPet.Tests;

using Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models;
using Models.Repository;
using Moq;

public class OrderControllerTests
{
	[Fact]
	public void CannotCheckoutEmptyCard()
	{
		//Arrange - Create mock repo
		Mock<IOrderRepository> mock = new();
		//Arrange - Create Empty cart
		DonationCart cart = new();
		//Arrange - Create order
		Order order = new();
		//Arrange - Create instance of Controller
		OrderController target = new(mock.Object, cart);
		
		//Act
		ViewResult? result = target.Checkout( order ) as ViewResult;
		
		//Assert - Check order hasn't been stored
		mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
		//Assert - Check the method returning default View
		Assert.True(string.IsNullOrEmpty( result?.ViewName ));
		//Assert - Check passing invalid model name
		Assert.False(result?.ViewData.ModelState.IsValid);
	}

	[Fact]
	public void CannotCheckoutInvalidDetails()
	{
		//Arrange - Create mock repo
		Mock<IOrderRepository> mock = new();

		// Arrange - create a cart with one item
		DonationCart cart = new();
		cart.AddItem( new Pet());

		// Arrange - create an instance of the controller
		OrderController target = new( mock.Object, cart );

		// Arrange - add an error to the model
		target.ModelState.AddModelError( "error", "error" );

		// Act - try to checkout
		ViewResult? result = target.Checkout( new Order() ) as ViewResult;

		// Assert - check that the order hasn't been passed stored
		mock.Verify( m => m.SaveOrder( It.IsAny<Order>() ), Times.Never );

		// Assert - check that the method is returning the default view
		Assert.True( string.IsNullOrEmpty( result?.ViewName ) );

		// Assert - check that I am passing an invalid model to the view
		Assert.False( result?.ViewData.ModelState.IsValid );
	}

	[Fact]
	public void Can_Checkout_And_Submit_Order()
	{
		// Arrange - create a mock order repository
		Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

		// Arrange - create a cart with one item
		DonationCart cart = new();
		cart.AddItem( new Pet());

		// Arrange - create an instance of the controller
		OrderController target = new OrderController( mock.Object, cart );

		// Act - try to checkout
		RedirectToPageResult? result =
			target.Checkout( new Order() ) as RedirectToPageResult;

		// Assert - check that the order has been stored
		mock.Verify( m => m.SaveOrder( It.IsAny<Order>() ), Times.Once );

		// Assert - check that the method is redirecting to the Completed action
		Assert.Equal( "/Completed", result?.PageName );
	}
}
