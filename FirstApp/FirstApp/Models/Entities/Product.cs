using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models.Enitities;

public class Product
{
    [Key]
    public Guid Id { get; set; }

    public required string ProductName { get; set; }

    public required float PricePerUnit { get; set; }

}