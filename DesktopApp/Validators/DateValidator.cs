using System.Globalization;
using System.Windows.Controls;

namespace DesktopApp.Validators;
internal class DateValidator:ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
		try
		{
			if (DateTime.TryParse(value.ToString(), out DateTime hireDate))
				return ValidationResult.ValidResult;
			else
				return new ValidationResult(false, $"Date must be in {DateTime.Now.ToShortDateString()} format.");
		}
		catch (Exception e)
		{
			return new ValidationResult(false, e.Message);
			throw;
		}
    }
}
