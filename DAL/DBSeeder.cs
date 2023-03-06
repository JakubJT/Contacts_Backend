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

        var categoryOne = new Category()
        {
            Name = "Business",
        };
        var categoryTwo = new Category()
        {
            Name = "Private"
        };
        var categoryThree = new Category()
        {
            Name = "Other",
            IsAddingSubcategoryPossible = true
        };
        context.AddRange(categoryOne, categoryTwo, categoryThree);
        context.SaveChanges();

        var subcategoryOne = new Subcategory()
        {
            Name = "Boss",
            IsDefaultSubcategory = true,
            CategoryId = categoryOne.CategoryId
        };
        var subcategoryTwo = new Subcategory()
        {
            Name = "Client",
            IsDefaultSubcategory = true,
            CategoryId = categoryOne.CategoryId
        };
        var subcategoryThree = new Subcategory()
        {
            Name = "Office",
            IsDefaultSubcategory = true,
            CategoryId = categoryOne.CategoryId
        };

        var subcategoryFour = new Subcategory()
        {
            Name = "Nowa",
            CategoryId = categoryThree.CategoryId
        };

        context.AddRange(subcategoryOne, subcategoryTwo, subcategoryThree, subcategoryFour);
        context.SaveChanges();

        var firstContact = new Contact()
        {
            Name = "Kazimierz",
            Surname = "Wielki",
            Password = "ffds333D",
            Category = categoryOne,
            Subcategory = subcategoryOne,
            PhoneNumber = "0000333"
        };
        var secondContact = new Contact()
        {
            Name = "Kazimierz",
            Surname = "Jagiellończyk",
            Password = "ffds",
            Category = categoryTwo,
            Subcategory = subcategoryTwo,
            PhoneNumber = "0000333"
        };
        var thirdContact = new Contact()
        {
            Name = "Bolesław",
            Surname = "Chrobry",
            Password = "ffds333",
            Category = categoryThree,
            Subcategory = subcategoryFour,
            PhoneNumber = "0000333"

        };
        context.AddRange(firstContact, secondContact, thirdContact);
        context.SaveChanges();

    }
}