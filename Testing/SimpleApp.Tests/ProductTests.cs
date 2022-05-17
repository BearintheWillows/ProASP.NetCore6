using SimpleApp.Models;
using Xunit;

namespace SimpleApp.Tests;

	public class ProductTests
	{
		[Fact]
		public void CanChangeProductName()
		{
			//Arrange
			var product = new Product { Name = "Test", Price = 100M };
			
			//Act
			product.Name = "new name";
			
			//Assert
			Assert.Equal("new name", product.Name);
		}

		[Fact]
		public void CanChangeProductPrice()
		{
			//Arrange
			var product = new Product { Name = "Test", Price = 100M };
			
			//Act
			product.Price = 200M;
			
			//Assert
			Assert.Equal(200M, product.Price);
		}
	}
	