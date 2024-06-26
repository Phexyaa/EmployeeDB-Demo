﻿using System.Globalization;
using System.Windows.Controls;

namespace DesktopApp
{
    class EmployeeAgeValidation : ValidationRule
    {
        private readonly int minimumAge = 0;
        private readonly int maximumAge = 100;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var age = (int)value;
                if (age < minimumAge)
                    return new ValidationResult(false, $"Employee cannot have an age less than {minimumAge}");
                if (age > maximumAge)
                    return new ValidationResult(false, $"Employee cannot have an age greater than {maximumAge}");
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
