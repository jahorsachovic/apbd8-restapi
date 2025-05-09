using System.ComponentModel.DataAnnotations;

namespace Tutorial8.Models.DTOs;

public class ClientDTO
{
    public int Id { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email must be of format <text>@<text>.<domain>")]
    public string Email { get; set; }
    
    [Required]
    public string Telephone { get; set; }
    
    [Required]
    [RegularExpression(@"\d{11}$", ErrorMessage = "PESEL must be 11 digits.")]
    public string Pesel { get; set; }
}