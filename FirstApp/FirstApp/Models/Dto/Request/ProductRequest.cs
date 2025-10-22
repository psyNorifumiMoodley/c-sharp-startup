using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models;

public class ProductRequest
{
    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(50, MinimumLength = 2)]
    public required string ProductName { get; set; }
    
    [Required(ErrorMessage = "Price per unit is required")]
    [Range(0.01, float.MaxValue, ErrorMessage = "Price must be above 0.01 ")]
    public required float PricePerUnit { get; set; }
}