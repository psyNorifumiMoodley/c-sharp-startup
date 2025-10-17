using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models.Enitities;

public class Item
{
    [Key]
    public Guid Id { get; set; }
    
    public Product Product { get; set; }
    
    public int Quantity { get; set; }
    
    public Cart Cart { get; set; }
}