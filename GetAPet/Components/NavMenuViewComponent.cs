namespace GetAPet.Components;

using Microsoft.AspNetCore.Mvc;
using Models.Repository;

public class NavMenuViewComponent : ViewComponent
{
	private IAppRepository _repository;
	public NavMenuViewComponent(IAppRepository repository)
	{
		_repository = repository;
	}

	public IViewComponentResult Invoke()
	{
		ViewBag.SelectedSpecies = RouteData.Values[ "species" ];
		if (ViewBag.SelectedSpecies != null)
		{
			Console.WriteLine("Viewbag = " + RouteData.Values["species"]);
		}
		return View( _repository.Pets
		                        .Select( p => p.Species )
		                        .Distinct()
		                        .OrderBy( p => p )
		);
	}
}