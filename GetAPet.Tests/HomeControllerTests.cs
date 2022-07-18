namespace GetAPet.Tests;

using Controllers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Pagination;
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
		PetListViewModel result =
			controller.Index(null)?.ViewData.Model as PetListViewModel ?? new();
		
		//Assert
		Pet[] pets = result.Pets.ToArray();
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
		PetListViewModel result = controller.Index( null, 2 )?.ViewData.Model
			as PetListViewModel ?? new();
		
		//Assert
		Pet[] pets = result.Pets.ToArray();
		Assert.True( pets.Length == 2 );
		Assert.Equal( "Scooby", pets[0].Name );
		Assert.Equal( "Scrappy", pets[1].Name );
	}

	[Fact]
	public void CanSendPaginationViewModel()
	{
		Mock<IAppRepository> mock = new();
		mock.Setup( m => m.Pets  ).Returns( new Pet[]
			{
			new() {Id = 1, Name = "Fido"},
			new() {Id = 2, Name = "Buddy"},
			new() {Id = 3, Name = "Spot"},
			new() {Id = 4, Name = "Scooby"},
			new() {Id = 5, Name = "Scrappy"},
			}.AsQueryable<Pet>());
		
		//Arrange
		HomeController controller = new( mock.Object ) {PageSize = 3 };
		
		//Act
		PetListViewModel result = controller.Index(null, 2 )?.ViewData.Model
			as PetListViewModel ?? new();
		
		//Assert
		PagingInfo pageInfo = result.PagingInfo;
		Assert.Equal( 2, pageInfo.CurrentPage );
		Assert.Equal( 3, pageInfo.ItemsPerPage );
		Assert.Equal( 5, pageInfo.TotalItems );
		Assert.Equal(2, pageInfo.TotalPages);
	}

	[Fact]
	public void CanFilterPets()
	{
		// Arrange
		// - Create the mock repository
		Mock<IAppRepository> mock = new();
		mock.Setup(m => m.Pets).Returns((new Pet[]
			{
			new Pet {Id = 1, Name = "Fido", Species = "Dog"},
			new Pet {Id = 2, Name = "Buddy", Species = "Dog"},
			new Pet {Id = 3, Name = "Spot", Species = "Dog"},
			new Pet {Id = 4, Name = "Scooby", Species = "Cat"},
			new Pet {Id = 5, Name = "Scrappy", Species = "Cat"},
			}.AsQueryable<Pet>()));
			
		//	Arrange - create a controller and make the page size 3 items
		HomeController controller = new(mock.Object);
		controller.PageSize = 3;
		
		//Action
		Pet[] result = ( controller.Index( "Cat", 1 )?.ViewData.Model as PetListViewModel ?? new() ).Pets.ToArray();
		
		//Assert
		Assert.Equal(2, result.Length);
		Assert.True( result[0].Name == "Scooby" && result[0].Species == "Cat" );
		Assert.True( result[1].Name == "Scrappy" && result[1].Species == "Cat" );
	}

	[Fact]
	public void GenerateSpeciesSpecificProductCount()
	{
		//Arrange
		Mock<IAppRepository> mock = new();
		mock.Setup(m => m.Pets).Returns((new Pet[]
			{
			new Pet {Id = 1, Name = "Fido", Species = "Dog"},
			new Pet {Id = 2, Name = "Buddy", Species = "Dog"},
			new Pet {Id = 3, Name = "Spot", Species = "Horse"},
			new Pet {Id = 4, Name = "Scooby", Species = "Cat"},
			new Pet {Id = 5, Name = "Scrappy", Species = "Cat"},
			}.AsQueryable<Pet>()));
		
		HomeController target = new(mock.Object);
		target.PageSize = 3;

		Func<ViewResult, PetListViewModel?> GetModel = result =>
			result?.ViewData?.Model as PetListViewModel;
		
		//Action
		int? res1 = GetModel(target.Index( "Dog" ))?.PagingInfo.TotalItems;
		int? res2 = GetModel(target.Index( "Cat" ))?.PagingInfo.TotalItems;
		int? res3 = GetModel(target.Index( "Horse" ))?.PagingInfo.TotalItems;
		int? resAll = GetModel(target.Index( null ))?.PagingInfo.TotalItems;
		
		//Assert
		Assert.Equal(2, res1);
		Assert.Equal(2, res2);
		Assert.Equal(1, res3);
		Assert.Equal(5, resAll);
		
	}
	
}