namespace WebApp.Controllers;

using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	private ApplicationDbContext _context;

	public ProductsController(ApplicationDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public IEnumerable<Product> GetProducts()
	{
		return _context.Products;
	}

	[HttpGet( "{id}" )]
	public Product? GetProduct(long id)
	{
		return _context.Products.FirstOrDefault( p => p.ProductId == id );
	}

	[HttpPost]
	public void SaveProduct([FromBody] Product product)
	{
		_context.Products.Add( product );
		_context.SaveChanges();
	}

	[HttpPut]
	public void UpdateProduct([FromBody] Product product)
	{
		_context.Products.Update( product );
		_context.SaveChanges();
	}

	[HttpDelete( "{id}" )]
	public void DeleteProduct(long id)
	{
		_context.Products.Remove(new Product() { ProductId = id });
		_context.SaveChanges();
	}
}