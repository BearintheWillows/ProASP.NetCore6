namespace WebApp.Models;

using System.ComponentModel.DataAnnotations.Schema;
using Data;
using Microsoft.AspNetCore.Mvc;
using Validation;

[PhraseAndPrice(Phrase = "small", Price = "100")]
public class Product
{
	public long ProductId { get; set; }

	public string Name { get; set; } = String.Empty;
	[Column(TypeName = "decimal(8,2)")]
	public decimal Price { get; set; }

	
	[PrimaryKey(ContextType = typeof(ApplicationDbContext), DataType = typeof(Category))]
	[Remote("CategoryKey", "Validation", ErrorMessage = "Enter existing Key")]
	public long CategoryId { get; set; }
	public Category? Category { get; set; }
	
	[PrimaryKey(ContextType = typeof(ApplicationDbContext), DataType = typeof(Category))]
	[Remote("SupplierKey", "Validation", ErrorMessage = "Enter existing Key")]
	public long SupplierId { get; set; }
	public Supplier? Supplier { get; set; }
}