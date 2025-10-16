namespace FirstApp.Models.Response;

public class CustomerResponse
{
    public Guid Id { get; set; } //global unique Id
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }

    public List<ProductResponse> Products { get; set; }
}