using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;

namespace SimpleApp.Controllers {
	
	public class HomeController : Controller
	{

		public IDataSource DataSource = new Product.ProductDataSource();
		public ViewResult Index()
		{
			return View(DataSource.Products);
		}
	}
}