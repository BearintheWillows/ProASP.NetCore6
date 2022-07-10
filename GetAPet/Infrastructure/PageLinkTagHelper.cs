namespace GetAPet.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Models.Pagination;

[HtmlTargetElement("div", Attributes = "page-model")]
public class PageLinkTagHelper : TagHelper
{
	private IUrlHelperFactory urlHelperFactory;

	public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
	{
		this.urlHelperFactory = urlHelperFactory;
	}
	
	[ViewContext]
	[HtmlAttributeNotBound]
	public ViewContext ViewContext { get; set; }
	public PagingInfo? PageModel { get;   set; }
	public string? PageAction { get; set; }

	public override void Process(
		TagHelperContext context,
		TagHelperOutput  output
	)
	{
		if ( ViewContext != null && PageModel != null )
		{
			IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
			TagBuilder result = new("div");
			for ( int i = 1; i < PageModel.TotalPages; i++ )
			{
				TagBuilder tag = new("a");
				tag.Attributes["href"] = urlHelper.Action(PageAction,
				                                          new { productPage = i });
				tag.InnerHtml.AppendHtml(i.ToString());
				result.InnerHtml.AppendHtml(tag);
			}
			output.Content.AppendHtml(result.InnerHtml);
		}
	}
}