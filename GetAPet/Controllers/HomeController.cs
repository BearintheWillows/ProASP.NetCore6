using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GetAPet.Models;

namespace GetAPet.Controllers;

using Models.Repository;

public class HomeController : Controller
{
	private IAppRepository _repository;
	public  int            PageSize = 4;
	public HomeController(IAppRepository repository)
	{
		_repository = repository;
	}
	
	public ViewResult Index(int productPage = 1)
	=> View(_repository.Pets
	                   .OrderBy(p => p.Id)
	                   .Skip( (productPage - 1) * PageSize)
	                   .Take(PageSize));
}