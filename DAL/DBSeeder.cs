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
            DoesHaveSubcategories = true
        };
        var categoryTwo = new Category()
        {
            Name = "Private"
        };
        var categoryThree = new Category()
        {
            Name = "Other",
            IsAddingSubcategoryPossible = true,
            DoesHaveSubcategories = true
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
            Password = "Abb333&&",
            Email = "malpa4@mapla.pl",
            Category = categoryOne,
            Subcategory = subcategoryOne,
            PhoneNumber = "012345678"
        };
        var secondContact = new Contact()
        {
            Name = "Kazimierz",
            Surname = "Jagiellończyk",
            Password = "Abb333***",
            Email = "malpa3@mapla.pl",
            Category = categoryOne,
            Subcategory = subcategoryTwo,
            PhoneNumber = "512365678"
        };
        var thirdContact = new Contact()
        {
            Name = "Bolesław",
            Surname = "Chrobry",
            Password = "dAbb333***",
            Email = "malpa1@mapla.pl",
            Category = categoryThree,
            Subcategory = subcategoryFour,
            PhoneNumber = "912445628"

        };
        var fourthContact = new Contact()
        {
            Name = "Bolesław II",
            Surname = "Niechrobry",
            Email = "malpa2@mapla.pl",
            Password = "Abb333***",
            Category = categoryTwo,
            PhoneNumber = "912445628"

        };
        context.AddRange(firstContact, secondContact, thirdContact, fourthContact);
        context.SaveChanges();

    }
}