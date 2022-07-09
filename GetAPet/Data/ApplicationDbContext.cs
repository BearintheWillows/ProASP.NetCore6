namespace GetAPet.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions options)
		: base(options) {}



	public DbSet<Pet> Pets => Set<Pet>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating( modelBuilder );

		modelBuilder.ApplyConfigurationsFromAssembly( typeof(ApplicationDbContext).Assembly );
	}
	
}