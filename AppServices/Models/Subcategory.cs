using System.ComponentModel.DataAnnotations;

namespace AppServices.Models;

public class Subcategory
{
    public int? SubcategoryId { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 3)]
    public string? Name { get; set; }

    public bool IsDefaultSubcategory { get; set; } = false;

    [Required]
    public int CategoryId { get; set; }
}