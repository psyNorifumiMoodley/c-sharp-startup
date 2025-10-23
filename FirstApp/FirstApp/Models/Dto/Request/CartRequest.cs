using System.ComponentModel.DataAnnotations;
using FirstApp.Models.Entities;

namespace FirstApp.Models;

public class CartRequest
{
    [Required(ErrorMessage = "Cart name is required")]
    [StringLength(50,  MinimumLength = 2, ErrorMessage = "Cart name must be between 2 and 50 characters")]
    public string CartName {get; set;}
    
    public List<Item> Items { get; set; } = new List<Item>();
}