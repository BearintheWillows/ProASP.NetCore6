namespace GetAPet.Models.Repository;

using Data;

public class EFAppRepository : IAppRepository
{
	private ApplicationDbContext _context;
	public EFAppRepository(ApplicationDbContext context)
	{
		_context = context;
	}
	
	public IQueryable<Pet> Pets => _context.Pets;


}