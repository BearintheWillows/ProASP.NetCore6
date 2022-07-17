using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GetAPet.Models;

namespace GetAPet.Controllers;

using Models.Pagination;
using Models.Repository;

public class HomeController : Controller
{
	private IAppRepository _repository;
	public  int            PageSize = 3;
	public HomeController(IAppRepository repository)
	{
		_repository = repository;
	}

	public ViewResult Index(string? species, int currentPage = 1) => View( new PetListViewModel()
		{
		Pets = _repository.Pets
		                  .Where( p => species == null || p.Species == species)
		                  .OrderBy( p => p.Id )
		                  .Skip( ( currentPage - 1 ) * PageSize )
		                  .Take( PageSize ),
		PagingInfo = new PagingInfo
			{
			CurrentPage = currentPage, ItemsPerPage = PageSize, TotalItems = _repository.Pets.Count()
			},
		CurrentSpecies = species
		});
}
