using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL;
public class ContactsContext : DbContext
{
    public ContactsContext()
    {
    }

    public ContactsContext(DbContextOptions<ContactsContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
=> options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Contacts;Trusted_Connection=True;TrustServerCertificate=True");

    public DbSet<Contact>? Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}

