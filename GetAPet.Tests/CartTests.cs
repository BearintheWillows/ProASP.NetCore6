namespace GetAPet.Tests;

using Models;

public class CartTests
{
	[Fact]
	public void CanAddNewLines()
	{
		//Arrange - Create test Pets
		Pet P1 = new Pet { Id = 1, Name = "Test Pet 1" };
		Pet P2 = new Pet { Id = 2, Name = "Test Pet 2" };
		
		//Arrange - Create new Cart
		DonationCart target = new();
		
		//Act
		target.AddItem(P1);
		target.AddItem(P2);
		CartLine[] results = target.Lines.ToArray();
		
		//Assert
		Assert.Equal( 2, results.Length );
		Assert.Equal( P1, results[0].Pet );
		Assert.Equal( P2, results[1].Pet );
	}

	[Fact]
	public void CanRemoveLine()
	{
		//Arrange - Create test Pets
		Pet P1 = new Pet { Id = 1, Name = "Test Pet 1" };
		Pet P2 = new Pet { Id = 2, Name = "Test Pet 2" };
		Pet P3 = new Pet { Id = 3, Name = "Test Pet 3" };
		
		//Arrange - Create a new cart
		DonationCart target = new();
		
		//Arrange - Add some test Pets to the cart
		target.AddItem(P1);
		target.AddItem(P2);
		target.AddItem(P3);
		
		//Act
		target.RemoveLine(P2);
		
		//Assert
		Assert.Empty(target.Lines.Where(c => c.Pet == P2));
		Assert.Equal(2, target.Lines.Count());

	}

	[Fact]
	public void CalculateCartTotal()
	{
		//Arrange
		Pet P1 = new Pet { Id = 1, Name = "Test Pet 1", Price = 100M };
		Pet P2 = new Pet { Id = 2, Name = "Test Pet 2", Price = 50M };
		
		//Arrange - Create a new cart
		DonationCart target = new();
		
		//Act
		target.AddItem( P1 );
		target.AddItem( P2 );
		decimal result = target.ComputeTotalValue();
		
		//Assert
		Assert.Equal( 150M, result );

	}

	[Fact]
	public void CanClearContents()
	{
		//Arrange - Create test Pets
		Pet P1 = new Pet { Id = 1, Name = "Test Pet 1", Price = 100M };
		Pet P2 = new Pet { Id = 2, Name = "Test Pet 2", Price = 50M };
		
		//Arrange - Create a new cart
		DonationCart target = new();
		
		//Arrange - Add some test Pets to the cart
		target.AddItem(P1);
		target.AddItem(P2);
		
		//Act - Reset cart
		target.Clear();
		
		//Assert
		Assert.Empty(target.Lines);
	}
}