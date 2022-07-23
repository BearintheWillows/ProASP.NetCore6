namespace GetAPet.Models.Repository;

using Data;
using Microsoft.EntityFrameworkCore;

public class EFOrderRepository : IOrderRepository
{

	private ApplicationDbContext _context;

	public EFOrderRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public IQueryable<Order> Orders => _context.Orders
	                                           .Include( o => o.Lines )
	                                           .ThenInclude( l => l.Pet );

	public void SaveOrder(Order order)
	{
		_context.AttachRange( order.Lines.Select( l => l.Pet ) );
		if ( order.OrderID == 0 )
		{
			_context.Orders.Add( order );
		}

		_context.SaveChanges();
	}
}
