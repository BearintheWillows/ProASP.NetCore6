namespace GetAPet.Tests;

using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Models.Repository;
using Moq;
using Pages;

public class CartPageTests
{
	[Fact]
	public void CanLoadCart()
	{
		//Arrange
		//Create mock repo
		Pet p1 = new Pet { Id = 1, Name = "Fido", Price = 100 };
		Pet p2 = new Pet { Id = 2, Name = "Buddy", Price = 200 };
		Mock<IAppRepository> mockRepo = new Mock<IAppRepository>();
		mockRepo.Setup(m => m.Pets).Returns((new Pet[] { p1, p2 }).AsQueryable<Pet>());
		
		//Create mock cart
		DonationCart cart = new DonationCart();
		cart.AddItem(p1);
		cart.AddItem(p2);
		
		//Create mock context and session
		Mock<ISession> mockSession = new Mock<ISession>();
		byte[] data = Encoding.UTF8.GetBytes( JsonSerializer.Serialize( cart ) );
		mockSession.Setup( m => m.TryGetValue( It.IsAny<string>(), out data ) );
		Mock<HttpContext> mockContext = new Mock<HttpContext>();
		mockContext.Setup( m => m.Session ).Returns( mockSession.Object );
		
		//Action
		Donate donatePage = new Donate( mockRepo.Object )
			{
			PageContext = new PageContext( new ActionContext
					{
					HttpContext = mockContext.Object,
					RouteData = new(),
					ActionDescriptor = new PageActionDescriptor()
					}
			)
			};
		donatePage.OnGet("myUrl");
		
		//Assert
		Assert.Equal(2, donatePage.Cart.Lines.Count);
		Assert.Equal("myUrl", donatePage.ReturnUrl);

	}
	
	
}