using FirstApp.Models.Enitities;

namespace FirstApp.Models;

public class ProductRequest
{
    public required string ProductName { get; set; }

    public required float PricePerUnit { get; set; }
}