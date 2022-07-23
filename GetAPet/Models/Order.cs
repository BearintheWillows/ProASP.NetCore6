namespace GetAPet.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class Order
{
	[BindNever]
	public int OrderID { get; set; }
	[BindNever]
	public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
	
	[Required(ErrorMessage = "Enter Name")]
	public string? Name { get; set; }
	
	[Required(ErrorMessage = "Enter first line of Address")]
	public string? Line1 { get; set; }
	public string? Line2 { get; set; }
	public string? Line3 { get; set; }
	
	[Required(ErrorMessage = "Enter City")]
	public string? City { get; set; }
	
	[Required(ErrorMessage = "Enter County")]
	public string? County { get; set; }
	
	public string? PostCode { get; set; }
	
	[Required(ErrorMessage = "Enter Country")]
	public string? Country { get; set; }
	
	public bool GiftAid { get; set; }
	
	[BindNever]
	public bool ReceivedDonation { get; set; }
	
}