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

    public async Task<int> CreateSubcategory(string subcategoryName, int categoryId)
    {
        var subcategoryId = await CheckIfSubcategoryExists(subcategoryName, categoryId);
        if (subcategoryId is not null) return (int)subcategoryId;

        Subcategory newSubcategory = new() { Name = subcategoryName, CategoryId = categoryId };
        _context.Subcategories!.Add(newSubcategory);
        await _context.SaveChangesAsync();
        return newSubcategory.SubcategoryId;
    }

    private async Task<int?> CheckIfSubcategoryExists(string subcategoryName, int categoryId)
    {
        var subcategory = await _context.Subcategories!
            .AsNoTracking()
            .Where(s => s.Name == subcategoryName && s.CategoryId == categoryId)
            .SingleOrDefaultAsync();
        if (subcategory is null) return null;
        return subcategory.SubcategoryId;
    }

}