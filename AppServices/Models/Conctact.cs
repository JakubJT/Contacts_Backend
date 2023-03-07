using System.ComponentModel.DataAnnotations;

namespace AppServices.Models;

public class Contact
{
    private const string ValidationPassword = "Hasło musi się składać z conajmniej 6 znaków, w tym 1 duże litery, jednej małe, cyfry, znaku specjalnego(za wyjątkiem spacji)";

    public int ContactId { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 3)]
    public string? Name { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 3)]
    public string? Surname { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(15, MinimumLength = 3)]
    public string? Email { get; set; }

    [StringLength(15, MinimumLength = 6)]
    [RegularExpression(@"(?=.*\d)(?=.*\W)(?=.*[a-z])(?=.*[A-Z])\S+", ErrorMessage = ValidationPassword)]
    public string? Password { get; set; }

    [Phone]
    [StringLength(9, MinimumLength = 9)]
    public string? PhoneNumber { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Subcategory? Subcategory { get; set; }
}