using System.ComponentModel.DataAnnotations;

namespace MinimalAPIValidationDemo.Models;

public record Person
{
    [Required]
    [Length(2, 50, ErrorMessage = "{0} must be between {1} and {2} characters long.")]
    [Display(Name = "First Name")]    
    public required string FirstName { get; set; }

    [Required]
    [Length(2, 50, ErrorMessage = "{0} must be between {1} and {2} characters long.")]
    [Display(Name = "Last Name")] 
    public required string LastName { get; set; }

    [EmailAddress]
    [Display(Name = "Email Address")]
    public required string Email { get; set; }

    [Required]
    [Length(10, 100, ErrorMessage = "{0} must be between {1} and {2} characters.")]    
    public required string Address { get; set; }

    public string? Address2 { get; set; }

    [Required]
    [Length(10, 100, ErrorMessage = "{0} must be between {1} and {2} characters.")]    
    public required string City { get; set; }

    [Required]
    [AllowedValues("NC, SC, VA, GA")]
    public required string State { get; set; }

    [Display(Name = "ZIP Code")]
    [RegularExpression(@"^\d{5}(?:-\d{4})?$",
       ErrorMessage = "{0} must be a valid US ZIP code (e.g. 12345 or 12345-6789).")]
    public required string ZipCode { get; set; }
}

