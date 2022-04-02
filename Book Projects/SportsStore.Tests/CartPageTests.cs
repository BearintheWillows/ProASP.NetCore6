﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Moq;
using SportsStore.Models;
using SportsStore.Pages;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Xunit;

namespace SportsStore.Tests;

public class CartPageTests
{
	[Fact]
	public void Can_Load_Cart()
	{
		//Arrange
		// - Create Mock repo

		Product                p1       = new() { ProductID = 1, Name = "P1" };
		Product                p2       = new() { ProductID = 2, Name = "P2" };
		Mock<IStoreRepository> mockRepo = new();
		mockRepo.Setup( m => m.Products )
		        .Returns(
			         new[]
			         {
				         p1, p2,
			         }.AsQueryable() );

		//Create cart
		Cart testCart = new();
		testCart.AddItem( p1, 2 );
		testCart.AddItem( p2, 1 );

		//Create mock page context and session
		Mock<ISession> mockSession = new();
		byte[]         data        = Encoding.UTF8.GetBytes( JsonSerializer.Serialize( testCart ) );
		mockSession.Setup( c => c.TryGetValue( It.IsAny<string>(), out data ) );
		Mock<HttpContext> mockContext = new();
		mockContext.SetupGet( c => c.Session ).Returns( mockSession.Object );

		//Action
		CartModel cartModel = new( mockRepo.Object )
		{
			PageContext = new PageContext(
				new ActionContext
				{
					HttpContext      = mockContext.Object,
					RouteData        = new RouteData(),
					ActionDescriptor = new PageActionDescriptor(),
				} ),
		};

		cartModel.OnGet( "myUrl" );

		//Assert
		Assert.Equal( 2, cartModel.Cart?.Lines.Count );
		Assert.Equal( "myUrl", cartModel.ReturnUrl );
	}

	[Fact]
	public void Can_Update_Cart()
	{
		//Arrange
		//Create repo
		Mock<IStoreRepository> mockRepo = new();
		mockRepo.Setup( m => m.Products )
		        .Returns(
			         new Product[]
			         {
				         new() { ProductID = 1, Name = "P1" },
			         }.AsQueryable<Product>() );

		Cart? testCart = new();

		Mock<ISession> mockSession = new();
		mockSession.Setup( s => s.Set( It.IsAny<string>(), It.IsAny<byte[]>() ) )
		           .Callback<string, byte[]>(
			            ( key, value ) =>
			            {
				            testCart = JsonSerializer.Deserialize<Cart>(
					            Encoding.UTF8.GetString
						            ( value ) );
			            } );

		Mock<HttpContext> mockContext = new();
		mockContext.SetupGet( c => c.Session ).Returns( mockSession.Object );

		//Action
		CartModel cartModel = new( mockRepo.Object )
		{
			PageContext = new PageContext(
				new ActionContext()
				{
					HttpContext      = mockContext.Object,
					RouteData        = new RouteData(),
					ActionDescriptor = new PageActionDescriptor(),
				} ),
		};
		cartModel.OnPost( 1, "myUrl" );

		//Asset
		Assert.Single( testCart.Lines );
		Assert.Equal( "P1", testCart.Lines.First().Product.Name );
		Assert.Equal( 1, testCart.Lines.First().Quantity );
	}
}