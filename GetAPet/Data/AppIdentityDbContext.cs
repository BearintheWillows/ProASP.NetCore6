
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace GetAPet.Data;

using Microsoft.AspNetCore.Identity;

public class AppIdentityDbContext : IdentityDbContext<IdentityUser> {

		public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
			: base(options) { }
	}
