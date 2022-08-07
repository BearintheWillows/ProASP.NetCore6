namespace WebApp.Controllers;

using Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ValidationController: ControllerBase {
	private ApplicationDbContext dataContext;
	public ValidationController(ApplicationDbContext context) {
		dataContext = context;
	}
	[HttpGet("categorykey")]
	public bool CategoryKey(string categoryId) {
		long keyVal;
		return long.TryParse(categoryId, out keyVal)
		    && dataContext.Categories.Find(keyVal) != null;
	}
	[HttpGet("supplierkey")]
	public bool SupplierKey(string supplierId) {
		long keyVal;
		return long.TryParse(supplierId, out keyVal)
		    && dataContext.Suppliers.Find(keyVal) != null;
	}
}