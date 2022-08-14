using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Advanced.Pages;

using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
	public class AdminPageModel: PageModel {
	}