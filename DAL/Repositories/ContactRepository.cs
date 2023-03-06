using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL;

namespace DAL.Repositories;

public class ContactRepository
{
    private readonly ContactsContext _context;
    public ContactRepository(ContactsContext context)
    {
        _context = context;
    }

    public async Task<List<Contact>> GetAllContacts()
    {
        var contacts = await _context.Contacts!
            .AsNoTracking()
            .Include(c => c.Category)
            .Include(c => c.Subcategory)
            .ToListAsync();
        return contacts;
    }

    public async Task<Contact?> GetContactById(int id)
    {
        var contact = await _context.Contacts!
            .AsNoTracking()
            .Include(c => c.Category)
            .Include(c => c.Subcategory)
            .FirstOrDefaultAsync(c => c.ContactId == id);
        return contact;
    }

    public async Task CreateContact(Contact contact)
    {
        _context.Contacts!.Add(contact);
        await _context.SaveChangesAsync();

    }
    public async Task EditContact(Contact contact)
    {
        _context.Update(contact);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContact(int contactId)
    {
        var contactToDelete = new Contact() { ContactId = contactId };
        _context.Contacts!.Remove(contactToDelete);
        await _context.SaveChangesAsync();
    }

}