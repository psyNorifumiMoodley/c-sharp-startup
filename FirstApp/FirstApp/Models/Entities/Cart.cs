using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models.Enitities;

public class Cart
{
    [Key]
    public Guid Id { get; set; }
    
    public string CartName { get; set; }
    
    public List<Item> Items { get; set; } = new List<Item>();

    public Customer Customer { get; set; } = null!;
}