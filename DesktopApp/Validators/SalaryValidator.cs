using System.Globalization;
using System.Windows.Controls;

namespace DesktopApp.Validators;
internal class SalaryValidator:ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
		try
		{
			if (decimal.TryParse(value.ToString(), out decimal salary))
				return ValidationResult.ValidResult;
			else
				return new ValidationResult(false, $"Salary must be in 0,000.00 format");
		}
		catch (Exception e)
		{
			return new ValidationResult(false, e.Message);
			throw;
		}
    }
}
