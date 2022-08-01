namespace WebApp.Controllers;

using Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
	private ApplicationDbContext _context;

	public SuppliersController(ApplicationDbContext? context)
	{
		_context = context;
	}
	
	[HttpGet("{id}")]
	public async Task<Supplier?> GetSupplier(long id)
	{
		Supplier supplier = await _context.Suppliers.Include( s => s.Products )
		                     .FirstOrDefaultAsync( s => s.SupplierId == id );
		if ( supplier?.Products != null )
		{
			foreach ( Product product in supplier.Products )
			{
				product.Supplier = null;
			}
		}

		return supplier;
	}

	[HttpPatch( "{id:long}" )]
	public async Task<Supplier?> PatchSupplier(long id, JsonPatchDocument<Supplier> patchDoc)
	{
		Supplier? supplier = await _context.Suppliers.FindAsync( id );
		if ( supplier != null )
		{
			patchDoc.ApplyTo( supplier );
			await _context.SaveChangesAsync();
		}
		return supplier;
	}
}