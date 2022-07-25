namespace GetAPet.Models;

using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class IdentitySeedData
{
	private const string adminUser = "Admin";
	private const string adminPassword = "Secret123!";

	public static async void EnsurePopulated(IApplicationBuilder app)
	{
		AppIdentityDbContext context = app.ApplicationServices
		                                  .CreateScope().ServiceProvider
		                                  .GetRequiredService<AppIdentityDbContext>();
		if ( context.Database.GetPendingMigrations().Any() )
		{
			context.Database.Migrate();
		}

		UserManager<IdentityUser> userManager = app.ApplicationServices
		                                           .CreateScope().ServiceProvider
		                                           .GetRequiredService<UserManager<IdentityUser>>();
		IdentityUser user = await userManager.FindByNameAsync( adminUser );
		if ( user is null )
		{
			user = new IdentityUser( "Admin" );
			user.Email = "admin@example.com";
			user.PhoneNumber= "555-555-5555";
			await userManager.CreateAsync( user, adminPassword );
		}
	}
}