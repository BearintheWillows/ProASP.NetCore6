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
				                       Species = "Dog",
				                       Breed = "Labrador",
				                       Color = "Black/White",
				                       Notes = "Bobby is a very good dog",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Daytona",
				                       Species = "Dog",
				                       Breed = "Collie",
				                       Color = "Black/White",
				                       Notes = "Daytona is an old boy.",
				                       Price = 150.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Suki",
				                       Species = "Dog",
				                       Breed = "Jack Russel",
				                       Color = "Tri-Color",
				                       Notes = "Suki is the best dog ever.",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Lexi",
				                       Species = "Dog",
				                       Breed = "Labrador/Collie",
				                       Color = "Tri-Color",
				                       Notes = "Lexi is a very good dog.",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Evigt",
				                       Species = "Dog",
				                       Breed = "Collie/Cocker Spaniel",
				                       Color = "Black/White",
				                       Notes = "Evigt-Poppy, why don't you stoppy",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Poppy",
				                       Species = "Dog",
				                       Breed = "Great Dane",
				                       Color = "Tan",
				                       Notes = "Poppy is a very good dog.",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Bella",
				                       Species = "Dog",
				                       Breed = "Labrador",
				                       Color = "Yellow",
				                       Notes = "Bella is a very good dog.",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Leeroy",
				                       Species = "Dog",
				                       Breed = "Collie",
				                       Color = "Black",
				                       Notes = "Leeroy the great.",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Jenkins",
				                       Species = "Dog",
				                       Breed = "Great Dane",
				                       Color = "Tan",
				                       Notes = "Least he has chicken",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Jack",
				                       Species = "Dog",
				                       Breed = "Labrador",
				                       Color = "Black",
				                       Notes = "Jack is back",
				                       Price = 100.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Joowah",
				                       Species = "Cat",
				                       Breed = "Siamese",
				                       Color = "Black",
				                       Notes = "Joowah is a very good cat.",	
				                       Price = 150.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Leo",
				                       Species = "Cat",
				                       Breed = "TortoiseShell",
				                       Color = "Giner",
				                       Notes = "Leo the lion",
				                       Price = 50.00m,
				                       },
			                       new Pet
				                       {
				                       Name = "Jackey",
				                       Species = "Horse",
				                       Breed = "Stallion",
				                       Color = "Black",
				                       Notes = "Jackey is a very good horse.",
				                       Price = 250.00m,
				                       }
			);
		}
		context.SaveChanges();
	}
}