using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public class Subcategory
{
    public int SubcategoryId { get; set; }
    public string? Name { get; set; }
    public bool IsDefaultSubcategory { get; set; } = false;
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}