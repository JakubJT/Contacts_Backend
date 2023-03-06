using System.ComponentModel.DataAnnotations;

namespace AppServices.Models;

public class Subcategory
{
    public int SubcategoryId { get; set; }
    public string? Name { get; set; }
    public bool IsDefaultSubcategory { get; set; } = false;
    public int CategoryId { get; set; }
}