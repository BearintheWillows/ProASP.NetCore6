using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;


namespace PartyInvites.Controllers;
public class HomeController : Controller
{
    public IActionResult Index() => View();

    [HttpGet]
    public ViewResult RsvpForm() => View();

    [HttpPost]
    public ViewResult RsvpForm( GuestResponse guestResp )
    {
        if ( ModelState.IsValid )
        {
            Repository.AddResponse( guestResp );
            return View( "Thanks", guestResp );
        }
        else
        {
            return View();
        }

    }

    public ViewResult ListResponses() => View( Repository.Responses.Where( r => r.WillAttend == true ) );

}
