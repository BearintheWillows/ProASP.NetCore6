using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Interfaces;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests;

public class HomeControllerTests
{
	[Fact]
	public void Can_Use_Repository()
	{
		//Arrange
		// - create the mock repository
		Mock<IStoreRepository> mock = new();
		
		// - create a product in repository
		mock.Setup( m => m.Products )
		    .Returns(new Product[]
		    {
			    new() { ProductID = 1, Name = "P1" },
			    new() { ProductID = 2, Name = "P2" }
		    }.AsQueryable());

		//Create controller using mock repository
		HomeController controller = new(mock.Object);
		
		//Act
		// - call the Index action
		IEnumerable<Product>? result = ( controller.Index() 
				as ViewResult )?.ViewData.Model
				as IEnumerable<Product>;
		
		//Assert
		// - check that the result is not null
		Product[] prodArray = result.ToArray() ?? Array.Empty<Product>();
		// - check that the result contains 2 products
		Assert.True(prodArray.Length == 2);
		// - check that the product names are correct
		Assert.Equal("P1", prodArray[0].Name);
		Assert.Equal("P2", prodArray[1].Name);
		
	}
}