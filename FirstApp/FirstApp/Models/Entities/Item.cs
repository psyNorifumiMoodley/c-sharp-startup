using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FirstApp.Models.Entities;
using FirstApp.Models.Validators;

namespace FirstApp.Models.Entities;

[Table("item")]
public class Item
{
    [Key]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Quantity is required")]
    [MinValue(0, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }
    
    public Product Product { get; set; }
    
    public Cart Cart { get; set; }
}