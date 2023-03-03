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
    }
}