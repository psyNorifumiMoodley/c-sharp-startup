using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FirstApp.Models.Validators;

namespace FirstApp.Models;

public class ItemRequest
{
    public Guid ProductId { get; set; }
    
    [Required(ErrorMessage = "Quantity is required")]
    [MinValue(0, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }
}