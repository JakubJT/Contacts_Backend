using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL;

namespace DAL.Repositories;

public class CategoryRepository
{
    private readonly ContactsContext _context;
    public CategoryRepository(ContactsContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllCategories()
    {
        var categories = await _context.Categories!
            .AsNoTracking()
            .ToListAsync();
        return categories;
    }

}