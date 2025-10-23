using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models;

public class CustomerRequest
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "FirstName must be between 2 and 50 characters")]
    public required string FirstName { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "LastName is required")]
    [MaxLength(50, ErrorMessage = "LastName is longer than 50 characters")]
    [MinLength(2, ErrorMessage = "LastName is shorter than 2 characters")]
    public required string LastName { get; set; }
    
    [Required]
    [Range(10, 99, ErrorMessage = "Must be older than 10yrs")]
    public required int Age { get; set; }
}