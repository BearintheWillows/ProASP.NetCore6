using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers;

public class HomeController : Controller
{
	private IStoreRepository _repository;
	public  int              PageSize = 4;

	public HomeController( IStoreRepository repo ) { _repository = repo; }

	public ViewResult Index( int productPage = 1 ) =>
		View(
			_repository.Products
			           .OrderBy( p => p.ProductID )
			           .Skip( ( productPage - 1 ) * PageSize )
			           .Take( PageSize ) );
}