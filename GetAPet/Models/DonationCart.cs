namespace GetAPet.Models;

public class DonationCart
{
	public List<CartLine> Lines { get; set; } = new List<CartLine>();

	public void AddItem(Pet pet)
	{
		CartLine? line = Lines
		   .FirstOrDefault( p => p.Pet.Id == pet.Id );

		if ( line == null )
		{
			Lines.Add( new CartLine { Pet = pet});
		}
		else
		{
			Console.WriteLine("Pet already in cart");
		}
	}

	public void RemoveLine(Pet pet) => Lines.RemoveAll( l => l.Pet.Id == pet.Id );

	public decimal ComputeTotalValue() => Lines.Sum( e => e.Pet.Price );
	
	public void Clear() => Lines.Clear();
}

public class CartLine
{
	public int CartLineId { get; set; }
	public Pet Pet        { get; set; } = new();
}