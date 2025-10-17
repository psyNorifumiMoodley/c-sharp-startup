using FirstApp.Models.Enitities;

namespace FirstApp.Models;

public class ItemRequest
{
    public Guid ProductId { get; set; }
    
    public int Quantity { get; set; }
}