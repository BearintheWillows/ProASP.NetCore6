namespace Advanced.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

public class Person {
	public long        PersonId     { get; set; }
	[Required(ErrorMessage = "Please enter your name")]
	[MinLength(3, ErrorMessage = "Name must be at least 3 characters long")]
	public string      Firstname    { get; set; } = String.Empty;
	[Required(ErrorMessage = "Please enter your last name")]
	[MinLength(3, ErrorMessage = "Last name must be at least 3 characters long")]
	public string      Surname      { get; set; } = String.Empty;
	[Range(1, long.MaxValue, ErrorMessage = "A Department must be selected")]
	public long        DepartmentId { get; set; }
	[Range(1, long.MaxValue, ErrorMessage = "A Location must be selected")]
	public long        LocationId   { get; set; }
	public Department? Department   { get; set; }
	public Location?   Location     { get; set; }
}