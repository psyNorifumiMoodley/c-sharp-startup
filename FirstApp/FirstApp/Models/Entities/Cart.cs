using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp.Models.Entities;

[Table("cart")]
public class Cart : CartRequest
{
    [Key]
    public Guid Id { get; set; }
    public Customer Customer { get; set; } = null!;
}