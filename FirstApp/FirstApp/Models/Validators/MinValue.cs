using System.ComponentModel.DataAnnotations;

namespace FirstApp.Models.Validators;

public class MinValue : ValidationAttribute
{
    private int minValue;
    
    public MinValue(int minValue)
    {
        this.minValue = minValue;
    }
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || (int) value > minValue)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult(ErrorMessage ?? "Value must be greater than " + minValue);
    }
}