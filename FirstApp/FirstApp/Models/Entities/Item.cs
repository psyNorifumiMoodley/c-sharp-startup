using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FirstApp.Models.Entities;

namespace FirstApp.Models.Entities;

[Table("item")]
public class Item
{
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Product Name is required")]
    public Product Product { get; set; }
    
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue,  ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }
    
    public Cart Cart { get; set; }
}