namespace GetAPet.Tests;

using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Models.Pagination;
using Moq;

public class PageLinkHelperTests
{
	[Fact]
	public void CanGeneratePageLinks()
	{
		// Arrange
		var urlHelper = new Mock<IUrlHelper>();
		urlHelper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
		         .Returns("Test/Page1")
		         .Returns("Test/Page2")
		         .Returns("Test/Page3");

		var urlHelperFactory = new Mock<IUrlHelperFactory>();
		urlHelperFactory.Setup( f => f.GetUrlHelper( It.IsAny<ActionContext>() ) )
		                .Returns( urlHelper.Object );

		var viewContext = new Mock<ViewContext>();
		
		PageLinkTagHelper helper = new( urlHelperFactory.Object )
		{
			PageModel = new PagingInfo
			{
				CurrentPage = 2,
				TotalItems = 28,
				ItemsPerPage = 10
			},
		ViewContext = viewContext.Object,
			PageAction = "Test"
		};
		TagHelperContext ctx = new(new TagHelperAttributeList(),
		                           new Dictionary<object, object>(),
		                           ""
		);
		
		var content = new Mock<TagHelperContent>();
		TagHelperOutput output = new("div",
		                             new TagHelperAttributeList(),
		                             (cache, encoder) => Task.FromResult( content.Object )
		);
		
		//Act
		helper.Process( ctx, output );
		
		//Assert
		Assert.Equal(@"<a href=""Test/Page1"">1</a>"
		           + @"<a href=""Test/Page2"">2</a>",
		output.Content.GetContent());
	}
}