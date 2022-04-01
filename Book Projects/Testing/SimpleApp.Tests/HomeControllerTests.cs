using System.Collections.Generic;
using LanguageFeatures.Controllers;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace SimpleApp.Tests;
public class HomeControllerTests
{
	[Fact]
	public void IndexActionModelIsComplete()
	{
		//Arrange
		var controller = new HomeController();
		Product[] products = new Product[]
		{
			new Product() { Name = "Kayak", Price      = 275M },
			new Product() { Name = "Lifejacket", Price = 48.95M },
		};
		
		// Act
		var model = (( ViewResult ) controller.Index())?.ViewData.Model as IEnumerable<Product>;
		
		//Assert
		
	}
}
