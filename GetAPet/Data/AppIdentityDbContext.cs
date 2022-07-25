namespace GetAPet.Data;

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
{
	public AppIdentityDbContext(DbContextOptions options) : base(options)
	{}
}