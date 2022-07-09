namespace GetAPet.Models;

public class Pet
{
	public int     Id          { get; set; }
	public string  Name        { get; set; } = String.Empty;
	public string  DateOfBirth { get; set; } = String.Empty;
	public string  Species     { get; set; } = String.Empty;
	public string  Breed       { get; set; } = String.Empty;
	public string  Color       { get; set; } = String.Empty;
	public string  Notes       { get; set; } = String.Empty;
	public decimal Price       { get; set; }

}