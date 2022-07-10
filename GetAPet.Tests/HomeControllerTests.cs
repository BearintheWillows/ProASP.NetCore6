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
}