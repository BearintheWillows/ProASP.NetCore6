using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetAPet.Pages;

using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Repository;

public class Donate : PageModel
{
	private IAppRepository _repository;

	public Donate(IAppRepository repository, DonationCart cartService)
	{
		_repository = repository;
		Cart = cartService;
	}
	
	public DonationCart? Cart      { get; set; }
	public string        ReturnUrl { get; set; } = "/";

	public void OnGet(string returnUrl)
	{
		ReturnUrl = returnUrl ?? "/";
		//Cart = HttpContext.Session.GetJson<DonationCart>( "cart" ) ?? new();
	}
	
	public IActionResult OnPost(long Id, string returnUrl)
	{
		Pet? pet = _repository.Pets.FirstOrDefault(p => p.Id == Id);
		if ( pet != null )
		{
			Cart.AddItem(pet);
		}
		return RedirectToPage(new {returnUrl = returnUrl});
	}

	public IActionResult OnPostRemove(long Id, string returnUrl)
	{
		Cart.RemoveLine( Cart.Lines.First(cl => cl.Pet.Id == Id).Pet );
		return RedirectToPage(new {returnUrl = returnUrl});
	}
}