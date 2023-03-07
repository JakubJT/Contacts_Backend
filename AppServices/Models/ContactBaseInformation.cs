using System.ComponentModel.DataAnnotations;

namespace AppServices.Models;

public class ContactBaseInformation
{
    public int ContactId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string Category { get; set; }
}