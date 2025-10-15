namespace FirstApp.Models.Enitities;

public class Customer
{
    public Guid Id { get; set; } //global unique Id
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
}