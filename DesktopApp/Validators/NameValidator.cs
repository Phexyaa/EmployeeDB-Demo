using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace DesktopApp.Validators;
internal class NameValidator : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
		try
		{
			StringValidator validator = new StringValidator(1, 45, "<>{}\\/>=");
			string name = (string)value;
            if(!string.IsNullOrWhiteSpace(name))
            {
                validator.Validate(name);
                return ValidationResult.ValidResult;
            }
            else
                return new ValidationResult(false, "Name cannot be blank");
        }
        catch (ArgumentException e)
        {
            return new ValidationResult(false, e.Message);
            throw;
        }
        catch (Exception e)
        {
            return new ValidationResult(false, e.Message);
            throw;
        }
    }
}
