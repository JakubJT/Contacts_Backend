namespace DAL.Models;

public class Contact
{
    public int ContactId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}