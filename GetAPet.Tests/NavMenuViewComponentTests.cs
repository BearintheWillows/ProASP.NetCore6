namespace GetAPet.Tests;

using Components;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Models;
using Models.Repository;
using Moq;

public class NavMenuViewComponentTests
{
	[Fact]
	public void CanSelectCategories()
	{
		//Arrange
		Mock<IAppRepository> mock = new();
		mock.Setup( m => m.Pets ).Returns( ( new Pet[]
				{
				new Pet { Id = 1, Name = "Pet 1", Species = "Cat" },
				new Pet { Id = 2, Name = "Pet 2", Species = "Dog" },
				new Pet { Id = 3, Name = "Pet 3", Species = "Cat" },
				new Pet { Id = 4, Name = "Pet 4", Species = "Horse" }
				} ).AsQueryable<Pet>()
		);
		NavMenuViewComponent target = new( mock.Object );
		
		// Act = get the set of categories
		string[] results = ((IEnumerable<string>?)(target.Invoke()
			                    as ViewViewComponentResult)?.ViewData?.Model
		                 ?? Enumerable.Empty<string>()).ToArray();
		
		//Assert
		Assert.True(Enumerable.SequenceEqual( new string[] {"Cat", "Dog", "Horse"}, results ));
		
		
	}
}