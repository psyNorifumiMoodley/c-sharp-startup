namespace FirstApp.Models.Enitities;

public class Product
{
    public Guid Id { get; set; }

    public required string ProductName { get; set; }

    public required float PricePerUnit { get; set; }

    public Customer Customer { get; set; } = null!;
}