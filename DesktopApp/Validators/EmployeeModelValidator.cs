using Shared.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Validators;
internal static class EmployeeModelValidator
{
    internal static bool Validate(Employee employee)
    {
        var nameValidator = new NameValidator();
        var ageValidator = new AgeValidator();
        var titleValidator = new EmployeeTitleValidator();
        var employeeIDValidator = new EmployeeIdValidator();
        var dateValidator = new DateValidator();
        var salaryValidator = new SalaryValidator();

        return employee.FirstName != null &&
            employee.LastName != null &&
            nameValidator.Validate(employee.FirstName, new CultureInfo("en")).IsValid
            && nameValidator.Validate(employee.LastName!, new CultureInfo("en")).IsValid
            && ageValidator.Validate(employee.Age, new CultureInfo("en")).IsValid
            && employeeIDValidator.Validate(employee.EmployeeId, new CultureInfo("en")).IsValid
            && dateValidator.Validate(employee.HireDate, new CultureInfo("en")).IsValid
            && salaryValidator.Validate(employee.Salary, new CultureInfo("en")).IsValid
            && titleValidator.Validate(employee.Title!, new CultureInfo("en")).IsValid;
    }
}
