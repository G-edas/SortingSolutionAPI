using System.ComponentModel.DataAnnotations;

public class CustomValidator : ValidationAttribute
{
    private readonly int _minValue;
    private readonly int _maxValue;

    public CustomValidator(int minValue, int maxValue)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int[] intArray)
        {
            foreach (var intValue in intArray)
            {
                if (intValue < _minValue || intValue > _maxValue)
                {
                    return new ValidationResult($"The value {intValue} is not between {_minValue} and {_maxValue}.");
                }
            }

            return ValidationResult.Success;
        }

        return new ValidationResult("Invalid input type. Expected an array of integers.");
    }
}