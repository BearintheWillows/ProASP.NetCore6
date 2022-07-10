namespace GetAPet.Models;

using Data;

public static class SeedData
{
	public static void EnsurePopulated(IApplicationBuilder app)
	{
		ApplicationDbContext context = app.ApplicationServices
		                                    .CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

		if ( !context.Pets.Any() )
		{
			context.Pets.AddRange( new Pet
				                       {
				                       Name = "Bobby",
				                       DateOfBirth = new DateTime( 1 / 1 / 2019 ),
				                       Species = "Dog",
				                       Breed = "Labrador",
				                       Color = "Black/White",
				                       Notes = "Bobby is a very good dog",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Daytona",
				                       DateOfBirth = new DateTime( 25 / 5 / 2010 ),
				                       Species = "Dog",
				                       Breed = "Collie",
				                       Color = "Black/White",
				                       Notes = "Daytona is an old boy.",
				                       Price = 150.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Suki",
				                       DateOfBirth = new DateTime( 19 / 3 / 2016 ),
				                       Species = "Dog",
				                       Breed = "Jack Russel",
				                       Color = "Tri-Color",
				                       Notes = "Suki is the best dog ever.",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Lexi",
				                       DateOfBirth = new DateTime( 21 / 2 / 2011 ),
				                       Species = "Dog",
				                       Breed = "Labrador/Collie",
				                       Color = "Tri-Color",
				                       Notes = "Lexi is a very good dog.",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Evigt",
				                       DateOfBirth = new DateTime( 6 / 7 / 2020 ),
				                       Species = "Dog",
				                       Breed = "Collie/Cocker Spaniel",
				                       Color = "Black/White",
				                       Notes = "Evigt-Poppy, why don't you stoppy",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Poppy",
				                       DateOfBirth = new DateTime( 3 / 1 / 2014 ),
				                       Species = "Dog",
				                       Breed = "Great Dane",
				                       Color = "Tan",
				                       Notes = "Poppy is a very good dog.",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Bella",
				                       DateOfBirth = new DateTime( 1 / 1 / 2012 ),
				                       Species = "Dog",
				                       Breed = "Labrador",
				                       Color = "Yellow",
				                       Notes = "Bella is a very good dog.",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Leeroy",
				                       DateOfBirth = new DateTime( 5 / 11 / 2022 ),
				                       Species = "Dog",
				                       Breed = "Collie",
				                       Color = "Black",
				                       Notes = "Leeroy the great.",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Jenkins",
				                       DateOfBirth = new DateTime( 2 / 3 / 2009 ),
				                       Species = "Dog",
				                       Breed = "Great Dane",
				                       Color = "Tan",
				                       Notes = "Least he has chicken",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Jack",
				                       DateOfBirth = new DateTime( 1 / 1 / 2008 ),
				                       Species = "Dog",
				                       Breed = "Labrador",
				                       Color = "Black",
				                       Notes = "Jack is back",
				                       Price = 100.00m,
				                       }
			);
		}
		context.SaveChanges();
	}
}