using Microsoft.Extensions.Options;
using Shared.Global;
using Shared.Models;

namespace Shared.Utility;

public class EmployeeFactory : IEmployeeFactory
{
    private readonly Defaults _defaults;
    public EmployeeFactory(IOptions<Defaults> defaults)
    {
        _defaults = defaults.Value;
    }
    public Employee CreateEmployee(string firstName, string lastName, int salary, string title, DateTime hireDate, int age = 0)
    {
        return new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            Salary = salary,
            Title = title,
            HireDate = hireDate
        };
    }
    public Employee CreateGenericEmployee()
    {
        return new Employee()
        {
            FirstName = "Drewt",
            LastName = "Tallse",
            Age = 72,
            Salary = 103400.50m,
            Title = _defaults.EmployeeTitles[new Random().Next(0, _defaults.EmployeeTitles.Count)],
            HireDate = DateTime.Now - new TimeSpan(22, 0, 0, 0)
        };
    }
}
