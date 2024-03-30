using System.Globalization;
using System.Windows.Controls;

namespace DesktopApp.Validators
{
    class EmployeeHireDateValidation : ValidationRule
    {
        private readonly DateTime minimumDate = DateTime.MinValue;
        private readonly DateTime maximumDate = DateTime.MaxValue;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var hireDate = (DateTime)value;
                if (hireDate > minimumDate)
                    return new ValidationResult(false, $"Employee cannot have a hire date earlier than {minimumDate}");
                else if (hireDate > maximumDate)
                    return new ValidationResult(false, $"Employee cannot have a hire date later than {maximumDate}");
                else
                    return ValidationResult.ValidResult;
            }
            catch (Exception e)
            {
                return new ValidationResult(false, e.Message);
            }
        }
    }
}
