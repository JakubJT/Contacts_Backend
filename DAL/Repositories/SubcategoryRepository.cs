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

}