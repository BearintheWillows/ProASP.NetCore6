namespace GetAPet.Models.Repository;

using Data;

public class EFAppRepository : IAppRepository
{
	private ApplicationDbContext _context;
	public EFAppRepository(ApplicationDbContext context)
	{
		_context = context;
	}
	
	public IQueryable<Pet> Pets             => _context.Pets;

	public void SavePet(Pet pet)
	{
		_context.SaveChanges();
	}

	public void DeletePet(Pet pet)
	{
		_context.Remove( pet );
		_context.SaveChanges();
	}

	public void CreatePet(Pet pet)
	{
		_context.Add( pet );
		_context.SaveChanges();
	}
}