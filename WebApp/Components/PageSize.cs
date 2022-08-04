namespace WebApp.Components;

using Microsoft.AspNetCore.Mvc;

public class PageSize : ViewComponent
{
	public async Task<IViewComponentResult> InvokeAsync()
	{
		HttpClient client = new HttpClient();
		HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
		return View(response.Content.Headers.ContentLength);
	}
}