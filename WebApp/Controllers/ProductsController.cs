namespace WebApp.Controllers;

using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
	public async IAsyncEnumerable<Product> GetProducts()
	{
		return _context.Products.AsAsyncEnumerable();
	}

	[HttpGet( "{id}" )]
	public async Task<Product?> GetProduct(long id)
	{
		return await _context.Products.FirstOrDefaultAsync( p => p.ProductId == id );
	}

	[HttpPost]
	public async Task SaveProduct([FromBody] Product product)
	{
		await _context.Products.AddAsync( product );
		await _context.SaveChangesAsync();
	}

	[HttpPut]
	public async Task UpdateProduct([FromBody] Product product)
	{
		_context.Products.Update( product );
		await _context.SaveChangesAsync();
	}

	[HttpDelete( "{id}" )]
	public async Task DeleteProduct(long id)
	{
		_context.Products.RemoveA(new Product() { ProductId = id });
		await _context.SaveChangesAsync();
	}
}