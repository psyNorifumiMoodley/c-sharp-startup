using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp.Models.Entities;
[Table("customer")]
public class Customer
{
    [Key]
    public Guid Id { get; set; } //global unique Id
    
    [Required(AllowEmptyStrings =  false, ErrorMessage = "FirstName is required")]      //Allow Empty Strings is set to false by default
    [StringLength(50, MinimumLength = 2, ErrorMessage = "FirstName must be between 2 and 50 characters")]
    public required string FirstName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "LastName is required")]
    [MaxLength(50, ErrorMessage = "LastName is longer than 50 characters")]
    [MinLength(2, ErrorMessage = "LastName is shorter than 2 characters")]
    public required string LastName { get; set; }
    
    [Required]
    [Range(10, 99, ErrorMessage = "Must be older than 10yrs")] //both inclusive
    public int Age { get; set; }
    
    public List<Cart> Carts { get; } = new List<Cart>();
}