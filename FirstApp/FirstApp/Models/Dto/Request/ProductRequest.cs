using System.ComponentModel.DataAnnotations;
using FirstApp.Models.Validators;

namespace FirstApp.Models;

public class ProductRequest
{
    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(50, MinimumLength = 2)]
    public required string ProductName { get; set; }
    
    [Required(ErrorMessage = "Price per unit is required")]
    [GreaterThanZero(ErrorMessage = "Price must be above 0")]
    public required float PricePerUnit { get; set; }
}