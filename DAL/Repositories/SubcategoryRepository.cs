using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL;

namespace DAL.Repositories;

public class SubcategoryRepository
{
    private readonly ContactsContext _context;
    public SubcategoryRepository(ContactsContext context)
    {
        _context = context;
    }

    public async Task<List<Subcategory>> GetAllDefaultSubcategories()
    {
        var subcategories = await _context.Subcategories!
            .AsNoTracking()
            .Where(s => s.IsDefaultSubcategory == true)
            .ToListAsync();
        return subcategories;
    }

    public async Task CreateSubcategory(string subcategoryName)
    {
        bool doesSubcategoryExist = await CheckIfSubcategoryExists(subcategoryName);
        if (doesSubcategoryExist) return;

        Subcategory newSubcategory = new() { Name = subcategoryName };
        _context.Subcategories!.Add(newSubcategory);
        await _context.SaveChangesAsync();
    }

    private async Task<bool> CheckIfSubcategoryExists(string subcategoryName)
    {
        var subcategory = await _context.Subcategories!
            .Where(s => s.Name == subcategoryName)
            .SingleOrDefaultAsync();
        if (subcategory is null) return false;
        return true;
    }

}