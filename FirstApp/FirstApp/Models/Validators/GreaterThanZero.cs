using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models.Validators;

public class GreaterThanZero : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // Checking if value is [Required] isn't the job of this validation attribute
        // Actual logic
        if (value == null || (float) value > 0)
        {
            return ValidationResult.Success;
        }
        
        return new ValidationResult(ErrorMessage ?? "Value is 0 or less than 0");
    }
}