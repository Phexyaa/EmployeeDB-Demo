using System.Configuration;
using System.Globalization;
using System.Windows.Controls;

namespace DesktopApp.Validators;
internal class EmployeeIdValidator : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        try
        {
            var employeeId = (string)value;
            StringValidator validator = new StringValidator(36, 36,"`~!@#$%^&*()_+={}[]|\\:;\"'<>,.?/");

            validator.Validate(employeeId);
            return ValidationResult.ValidResult;
        }
        catch (InvalidCastException)
        {
            return new ValidationResult(false, $"Employee ID Format must be similar to the following: {Guid.NewGuid()}");
        }
        catch (Exception e)
        {
            return new ValidationResult(false, e.Message);
            throw;
        }
    }
}
