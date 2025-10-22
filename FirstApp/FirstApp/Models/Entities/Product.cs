using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp.Models.Entities;

[Table("product")]
public class Product : ProductRequest
{
    [Key]
    public Guid Id { get; set; }
}