using FirstApp.Models.Enitities;

namespace FirstApp.Models.Response;

public class ItemResponse
{
    public ProductResponse Product { get; set; }
    
    public int Quantity { get; set; }
    
    // public CartResponse Cart { get; set; }
}