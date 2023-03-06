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
=> options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ContactsDataBase;Trusted_Connection=True;TrustServerCertificate=True");

    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Subcategory>? Subcategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().ToTable("Contact");
        modelBuilder.Entity<Category>().ToTable("Category");
        modelBuilder.Entity<Subcategory>().ToTable("Subcategory");

        modelBuilder.Entity("DAL.Models.Contact", b =>
     {
         b.HasOne("DAL.Models.Category", "Category")
             .WithMany()
             .HasForeignKey("CategoryId")
             .OnDelete(DeleteBehavior.NoAction)
             .IsRequired();

         b.HasOne("DAL.Models.Subcategory", "Subcategory")
             .WithMany()
             .HasForeignKey("SubcategoryId")
             .OnDelete(DeleteBehavior.NoAction)
             .IsRequired();
     });
    }
}

