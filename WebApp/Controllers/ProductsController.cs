using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers;

using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	private ApplicationDbContext _context;

	public ProductsController(ApplicationDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public IAsyncEnumerable<Product> GetProducts()
	{
		return _context.Products.AsAsyncEnumerable();
	}

	[HttpGet( "{id}" )]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetProduct(long id)
	{
		Product? p = await _context.Products.FindAsync(id);
		if ( p == null )
		{
			return NotFound();
		}
		return Ok( p );
	}

	[HttpPost]
	public async Task<IActionResult> SaveProduct(ProductBindingTarget target)
	{
		Product p = target.ToProduct();
		await _context.Products.AddAsync( p );
		await _context.SaveChangesAsync();
		return Ok( p );}

	[HttpPut]
	public async Task UpdateProduct(Product product)
	{
		_context.Products.Update( product );
		await _context.SaveChangesAsync();
	}

	[HttpDelete( "{id}" )]
	public async Task DeleteProduct(long id)
	{
		_context.Products.Remove(new Product() { ProductId = id });
		await _context.SaveChangesAsync();
	}
}