namespace GetAPet.Tests;

using Controllers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Repository;
using Moq;
using NuGet.Frameworks;

public class HomeControllerTests
{
	[Fact]
	public void CanUseRepository()
	{
		// Arrange
		Mock<IAppRepository> mock = new();
		mock.Setup(m => m.Pets  ).Returns( new Pet[]
			{
			new() {Id = 1, Name = "Fido"},
			new() {Id = 2, Name = "Buddy"},
			}.AsQueryable());
		
		HomeController controller = new( mock.Object );
		
		//Act
		IEnumerable<Pet>? result = 
			(controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Pet>;
		
		//Assert
		Pet[] pets = result?.ToArray() ?? Array.Empty<Pet>();
		Assert.True( pets.Length == 2 );
		Assert.Equal( "Fido", pets[0].Name );
		Assert.Equal( "Buddy", pets[1].Name );
	}

	[Fact]
	public void CanPaginate()
	{
		// Arrange
		Mock<IAppRepository> mock = new();
		mock.Setup( m => m.Pets  ).Returns( new Pet[]
			{
			new() {Id = 1, Name = "Fido"},
			new() {Id = 2, Name = "Buddy"},
			new() {Id = 3, Name = "Spot"},
			new() {Id = 4, Name = "Scooby"},
			new() {Id = 5, Name = "Scrappy"},
			}.AsQueryable<Pet>());
		
		HomeController controller = new( mock.Object );
		controller.PageSize = 3;
		
		// Act
		IEnumerable<Pet> result =
			( controller.Index( 2 ) as ViewResult )?.ViewData.Model
			as IEnumerable<Pet> ?? Enumerable.Empty<Pet>();
		
		//Assert
		Pet[] pets = result.ToArray();
		Assert.True( pets.Length == 2 );
		Assert.Equal( "Scooby", pets[0].Name );
		Assert.Equal( "Scrappy", pets[1].Name );
	}
	
	
}