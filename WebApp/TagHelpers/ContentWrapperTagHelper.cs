namespace WebApp.TagHelpers;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

	[HtmlTargetElement("*", Attributes = "[wrap=true]")]
	public class ContentWrapperTagHelper: TagHelper {
		public override void Process(TagHelperContext context,
		                             TagHelperOutput  output) {
			TagBuilder elem = new ("div");
			elem.Attributes["class"] = "bg-primary text-white p-2 m-2";
			elem.InnerHtml.AppendHtml("Wrapper");
			output.PreElement.AppendHtml(elem);
			output.PostElement.AppendHtml(elem);
		}
	}
