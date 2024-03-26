using Shared.Models;

namespace API.Data;

public class EmployeeFactory : IEmployeeFactory
{
    public Person CreateEmployee(string firstName, string lastName, int salary, string title, DateTime hireDate, int age = 0)
    {
        return new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            Salary = salary,
            Title = title,
            HireDate = hireDate,
        };
    }
}
