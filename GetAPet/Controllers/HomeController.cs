using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GetAPet.Models;

namespace GetAPet.Controllers;

using Models.Repository;

public class HomeController : Controller
{
	private IAppRepository _repository;
	
	public HomeController(IAppRepository repository)
	{
		_repository = repository;
	}
	public IActionResult Index() => View(_repository.Pets);
}