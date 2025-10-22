namespace FirstApp.Models.Response;

public class CartResponse
{
    public Guid Id { get; set; }
    
    public string CartName { get; set; }
    
    public List<ItemResponse> Items { get; set; }
}