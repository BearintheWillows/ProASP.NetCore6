namespace PartyInvites.Models;
using System.ComponentModel.DataAnnotations;

public class GuestResponse
{
    [Required( ErrorMessage = "Please enter your name" )]
    public string? Name { get; set; }
    [Required( ErrorMessage = "Please enter email address" )]
    public string? Email { get; set; }
    [Required( ErrorMessage = "Please enter phone number" )]
    public string? PhoneNumber { get; set; }
    [Required( ErrorMessage = "Please specify if you will attend" )]
    public bool WillAttend { get; set; }
}
