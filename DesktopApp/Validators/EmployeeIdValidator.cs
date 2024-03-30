using System.Globalization;
using System.Windows.Controls;

namespace DesktopApp.Validators;
internal class EmployeeIdValidator : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        try
        {
            var id = (Guid)value;
            return ValidationResult.ValidResult;
        }
        catch (InvalidCastException e)
        {
            return new ValidationResult(false, $"EmployeeID Format must match the following: {Guid.NewGuid()}");
        }
        catch (Exception e)
        {
            return new ValidationResult(false, e.Message);
            throw;
        }
    }
}
