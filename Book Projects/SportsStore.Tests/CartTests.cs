﻿using System.Linq;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests;

public class CartTests
{
	[Fact]
	public void Can_Add_New_Lines()
	{
		//Arrange - Create some test products

		Product p1 = new() { ProductID = 1, Name = "P1" };
		Product p2 = new() { ProductID = 2, Name = "P2" };

		// Arrange - Create a Cart
		Cart target = new();

		//Act
		target.AddItem( p1, 1 );
		target.AddItem( p2, 1 );
		Cart.CartLine[] results = target.Lines.ToArray();

		//Assert
		Assert.Equal( 2, results.Length );
		Assert.Equal( p1, results[ 0 ].Product );
		Assert.Equal( p2, results[ 1 ].Product );
	}

	[Fact]
	public void Can_Add_For_Existing_Lines()
	{
		//Arrange - Create some test products

		Product p1 = new() { ProductID = 1, Name = "P1" };
		Product p2 = new() { ProductID = 2, Name = "P2" };

		// Arrange - Create a Cart
		Cart target = new();

		//Act
		target.AddItem( p1, 1 );
		target.AddItem( p2, 1 );
		target.AddItem( p1, 10 );
		Cart.CartLine[] results = target.Lines.OrderBy( c => c.Product.ProductID ).ToArray();

		//Assert
		Assert.Equal( 2, results.Length );
		Assert.Equal( 11, results[ 0 ].Quantity );
		Assert.Equal( 1, results[ 1 ].Quantity );
	}

	[Fact]
	public void Calculate_Cart_Total()
	{
		//Arrange - Create some test products
		Product p1 = new() { ProductID = 1, Name = "P1", Price = 100M };
		Product p2 = new() { ProductID = 2, Name = "P2", Price = 50M };

		//Arrange - Create a new cart
		Cart target = new();

		//Act
		target.AddItem( p1, 1 );
		target.AddItem( p2, 1 );
		target.AddItem( p1, 3 );
		decimal result = target.ComputeTotalValue();

		//Assert
		Assert.Equal( 450M, result );
	}

	[Fact]
	public void Can_Clear_Contents()
	{
		//Arrange - Create some test products
		Product p1 = new() { ProductID = 1, Name = "P1", Price = 100M };
		Product p2 = new() { ProductID = 2, Name = "P2", Price = 50M };

		//Arrange - Create a new cart
		Cart target = new();

		//Arrange - Add some items
		target.AddItem( p1, 1 );
		target.AddItem( p2, 1 );

		//Act - reset the cart
		target.Clear();

		//Assert
		Assert.Empty( target.Lines );
	}
}