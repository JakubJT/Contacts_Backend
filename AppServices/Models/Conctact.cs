using System.ComponentModel.DataAnnotations;

namespace AppServices.Models;

public class Contact
{
    public int ContactId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
    // [RegularExpression(@"(?=(.*\d)+)(?=(.*\W)+)(?=(.*[A-Z])+)(?=(.*[a-z])+)")]
    public string? Password { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public int CategoryId { get; set; }
    public Subcategory Subcategory { get; set; }
}