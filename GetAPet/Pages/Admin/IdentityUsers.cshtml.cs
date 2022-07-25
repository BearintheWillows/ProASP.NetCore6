using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetAPet.Pages.Admin;

using Microsoft.AspNetCore.Identity;

public class IdentityUsers : PageModel
{
	private UserManager<IdentityUser> _userManager;

	public IdentityUsers(UserManager<IdentityUser> userManager)
	{
		_userManager = userManager;
	}

	public IdentityUser AdminUser { get; set; } = new();
	public async void OnGetAsync()
	{
		AdminUser = await _userManager.FindByNameAsync( "Admin" );
	}
}