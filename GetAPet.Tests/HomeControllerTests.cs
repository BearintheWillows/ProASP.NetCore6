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
			controller.Index()?.ViewData.Model as PetListViewModel ?? new();
		
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
		PetListViewModel result = controller.Index( 2 )?.ViewData.Model
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
		PetListViewModel result = controller.Index( 2 )?.ViewData.Model
			as PetListViewModel ?? new();
		
		//Assert
		PagingInfo pageInfo = result.PagingInfo;
		Assert.Equal( 2, pageInfo.CurrentPage );
		Assert.Equal( 3, pageInfo.ItemsPerPage );
		Assert.Equal( 5, pageInfo.TotalItems );
		Assert.Equal(2, pageInfo.TotalPages);
	}
	
	
}