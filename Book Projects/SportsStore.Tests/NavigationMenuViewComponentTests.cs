using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using SportsStore.Components;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests;

public class NavigationMenuViewComponentTests
{
	[Fact]
	public void Can_Select_Categories()
	{
		//Arrange
		Mock<IStoreRepository> mock = new();
		mock.Setup( m => m.Products )
		    .Returns(
			     new Product[]
			     {
				     new() { ProductID = 1, Name = "P1", Category = "Apples" },
				     new() { ProductID = 2, Name = "P2", Category = "Apples" },
				     new() { ProductID = 3, Name = "P3", Category = "Plums" },
				     new() { ProductID = 4, Name = "P4", Category = "Oranges" },
			     }.AsQueryable<Product>() );

		NavigationMenuViewComponent target = new( mock.Object );

		//Act - Get categories
		string?[] results = ( ( IEnumerable<string?> ) ( target.Invoke()
			                      as ViewViewComponentResult )?.ViewData?.Model
		                   ?? Enumerable.Empty<string>() ).ToArray();

		//Assert
		Assert.True(
			Enumerable.SequenceEqual( new string[] { "Apples", "Oranges", "Plums" }, results ) );
	}

	[Fact]
	public void Indicates_Selected_Category()
	{
		string                 categoryToSelect = "Apples";
		Mock<IStoreRepository> mock             = new();
		mock.Setup( m => m.Products )
		    .Returns(
			     new Product[]
			     {
				     new() { ProductID = 1, Name = "P1", Category = "Apples" },
				     new() { ProductID = 4, Name = "P2", Category = "Oranges" },
			     }.AsQueryable<Product>() );

		NavigationMenuViewComponent target = new( mock.Object );
		target.ViewComponentContext = new ViewComponentContext
		{
			ViewContext = new ViewContext
			{
				RouteData = new RouteData(),
			},
		};
		target.RouteData.Values[ "category" ] = categoryToSelect;

		string result
			= ( string ) ( target.Invoke() as ViewViewComponentResult ).ViewData[
				"SelectedCategory" ];

		Assert.Equal( categoryToSelect, result );
	}
}