using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetAPet.Pages;

using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Repository;

public class Donate : PageModel
{
	private IAppRepository _repository;

	public Donate(IAppRepository repository)
	{
		_repository = repository;
	}
	
	public DonationCart? Cart      { get; set; }
	public string        ReturnUrl { get; set; } = "/";

	public void OnGet(string returnUrl)
	{
		ReturnUrl = returnUrl ?? "/";
		Cart = HttpContext.Session.GetJson<DonationCart>( "cart" ) ?? new();
	}
	
	public IActionResult OnPost(long Id, string returnUrl)
	{
		Pet? pet = _repository.Pets.FirstOrDefault(p => p.Id == Id);
		if ( pet != null )
		{
			Cart = HttpContext.Session.GetJson<DonationCart>("cart"  ) ?? new();
			Cart.AddItem(pet);
			HttpContext.Session.SetJson( "cart", Cart );
			
		}
		return RedirectToPage(new {returnUrl = returnUrl});
	}
}