using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models.Enitities;

public class Customer
{
    [Key]
    public Guid Id { get; set; } //global unique Id
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }

    public List<Cart> Carts { get; } = new List<Cart>();
}