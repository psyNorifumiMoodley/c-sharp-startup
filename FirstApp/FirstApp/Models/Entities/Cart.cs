using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp.Models.Entities;

[Table("cart")]
public class Cart
{
    [Key]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Cart name is required")]
    [StringLength(50,  MinimumLength = 2, ErrorMessage = "Cart name must be between 2 and 50 characters")]
    public string CartName { get; set; }
    
    public List<Item> Items { get; set; } = new List<Item>();

    public Customer Customer { get; set; } = null!;
}