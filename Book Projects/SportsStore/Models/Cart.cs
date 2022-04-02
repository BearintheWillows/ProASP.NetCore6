﻿namespace SportsStore.Models;

public class Cart
{
	public List<CartLine> Lines { get; set; } = new();

	public void AddItem( Product product, int quantity )
	{
		Console.WriteLine( product.Name );
		CartLine? line = Lines
		   .FirstOrDefault( p => p.Product.ProductID == product.ProductID );

		if ( line == null )
		{
			Lines.Add(
				new CartLine
				{
					Product  = product,
					Quantity = quantity,
				} );
		}
		else
		{
			line.Quantity += quantity;
		}

		Console.WriteLine( product.Name );
	}

	public void RemoveLine( Product product ) =>
		Lines.RemoveAll( l => l.Product.ProductID == product.ProductID );

	public decimal ComputeTotalValue() => Lines.Sum( e => e.Product.Price * e.Quantity );

	public void Clear() => Lines.Clear();

	#region Nested type: CartLine

	public class CartLine
	{
		public int     CartLineID { get; set; }
		public Product Product    { get; set; } = new();
		public int     Quantity   { get; set; }
	}

	#endregion
}