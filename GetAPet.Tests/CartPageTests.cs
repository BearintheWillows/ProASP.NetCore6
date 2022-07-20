namespace GetAPet.Tests;

using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Models.Repository;
using Moq;
using Pages;

public class CartPageTests
{
	[Fact]
	public void CanLoadCart()
	{
		//Arrange
		//Create mock repo
		Pet p1 = new Pet { Id = 1, Name = "Fido", Price = 100 };
		Pet p2 = new Pet { Id = 2, Name = "Buddy", Price = 200 };
		Mock<IAppRepository> mockRepo = new Mock<IAppRepository>();
		mockRepo.Setup(m => m.Pets).Returns((new Pet[] { p1, p2 }).AsQueryable<Pet>());
		
		//Create mock cart
		DonationCart cart = new DonationCart();
		cart.AddItem(p1);
		cart.AddItem(p2);

		//Action
		Donate cartModel = new(mockRepo.Object, cart);
		cartModel.OnGet("myUrl");
		
		//Assert
		Assert.Equal(2, cartModel.Cart.Lines.Count);
		Assert.Equal("myUrl", cartModel.ReturnUrl);

	}
	
	
}