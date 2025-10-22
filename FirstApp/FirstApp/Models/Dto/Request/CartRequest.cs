using FirstApp.Models.Entities;

namespace FirstApp.Models;

public class CartRequest
{
    public string CartName {get; set;}
    
    public List<Item> Products { get; set; } = new List<Item>();
}