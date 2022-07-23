namespace GetAPet.Models;

using System.ComponentModel.DataAnnotations;

public class Pet
{
	public int?     Id      { get; set; }
	[Required(ErrorMessage = "Please enter a name")]
	public string  Name    { get; set; } = String.Empty;
	[Required(ErrorMessage = "Please enter a Species")]
	public string  Species { get; set; } = String.Empty;
	[Required(ErrorMessage = "Please enter a Breed")]
	public string  Breed   { get; set; } = String.Empty;
	public string  Color   { get; set; } = String.Empty;
	public string  Notes   { get; set; } = String.Empty;
	[Required]
	[Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid price")]
	public decimal Price   { get; set; }

}