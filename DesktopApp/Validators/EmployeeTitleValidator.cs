using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Global;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopApp.Validators
{
    class EmployeeTitleValidator : ValidationRule
    {
        private readonly Defaults _defaults;

        public EmployeeTitleValidator()
        {
            var defaults = App.Current.Services.GetService<IOptionsMonitor<Defaults>>();
            if (defaults != null)
                _defaults = defaults.CurrentValue;
            else
                throw new NullReferenceException(nameof(_defaults));
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var title = (string)value;
                if (_defaults.EmployeeTitles.Contains(title))
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, $"Title is case sensitive and must be one of the following: {JsonSerializer.Serialize(_defaults.EmployeeTitles)}");
            }
            catch (Exception e)
            {
                return new ValidationResult(false, e.Message);
            }
        }
    }
}
