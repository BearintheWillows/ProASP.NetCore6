using Microsoft.AspNetCore.Mvc;

namespace PartyInvites.Controllers;

using Models;

public class HomeController : Controller
{
	public IActionResult Index() => View();

	[HttpGet]
	public ViewResult RsvpForm() => View();

	[HttpPost]
	public ViewResult RsvpForm(GuestResponse guestResponse)
	{
		if ( ModelState.IsValid )
		{
			Repository.AddResponse( guestResponse );
			return View( "Thanks", guestResponse );
		} else
			return View();
	}

	[HttpGet]
	public ViewResult ListResponses() => View( Repository.Responses.Where( r => r.WillAttend == true ) );
}