using DAL.Models;

namespace DAL;
public static class DBSeeder
{
    public static void Seed(ContactsContext context)
    {
        if (context.Contacts!.Any())
        {
            return;
        }

        var firstContact = new Contact()
        {
            Name = "Kazimierz",
            Surname = "Wielki",
            Password = "ffds333D"
        };

        var secondContact = new Contact()
        {
            Name = "Kazimierz",
            Surname = "Jagiellończyk",
            Password = "ffds333D"

        };

        context.AddRange(firstContact, secondContact);
        context.SaveChanges();
    }
}