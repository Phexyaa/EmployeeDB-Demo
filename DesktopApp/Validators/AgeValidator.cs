using System.Globalization;
using System.Windows.Controls;

namespace DesktopApp.Validators;
internal class AgeValidator : ValidationRule
{
    private const int MinimumAge = 18;
    private const int MaximumAge = 100;
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        try
        {
            if (value != null)
            {
                var age = (int)Decimal.Parse(value.ToString()) ;
                if (age < MinimumAge || age > MaximumAge)
                    return new ValidationResult(false, $"Age must be between: {MinimumAge} and {MaximumAge}");
                else
                    return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, $"Age cannot be blank.");
        }
        catch (Exception e)
        {
            return new ValidationResult(false, e.Message);
            throw;
        }
    }
}
