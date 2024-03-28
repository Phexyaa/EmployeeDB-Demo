using Shared.Interfaces;
using Shared.Models;
using Shared.Utility;
using System.Linq.Expressions;

namespace Shared.Test;

public class MockDataAccess : IDataService
{
    private readonly IEmployeeFactory _employeeFactory;
    public MockDataAccess(IEmployeeFactory employeeFactory)
    {
        _employeeFactory = employeeFactory;
    }


    public Task<Employee>? GetEmployeeByDatabaseId(int databaseId)
    {
        var employee = _employeeFactory.CreateGenericEmployee();
        employee.Id = databaseId;
        return Task.Run(()=> employee);
    }

    public Task<Employee> GetEmployeeByEmployeeId(Guid id)
    {
        var employee = _employeeFactory.CreateGenericEmployee();
        employee.EmployeeId = id;
        return Task.Run(() => employee);
    }
    public Task<IQueryable<Employee>>? GetAllActiveEmployees()
    {
        var result = new List<Employee>();
        for (int i = 0; i < new Random().Next(50, 100); i++)
        {
            var employee = _employeeFactory.CreateGenericEmployee();
            employee.IsActive = true;
            result.Add(employee);
        }
        return Task.Run(() => result.AsQueryable());
    }

    public Task<IQueryable<Employee>>? GetAllEmployees()
    {
        var result = new List<Employee>();
        for (int i = 0; i < new Random().Next(50, 100); i++)
        {
            result.Add(_employeeFactory.CreateGenericEmployee());
        }
        return Task.Run(() => result.AsQueryable());
    }

    public Task<IQueryable<Employee>>? GetAllInactiveEmployees()
    {
        var result = new List<Employee>();
        for (int i = 0; i < new Random().Next(50, 100); i++)
        {
            var employee = _employeeFactory.CreateGenericEmployee();
            employee.IsActive = false;
            result.Add(employee);
        }
        return Task.Run(() => result.AsQueryable());
    }

    public Task<IQueryable<Employee>>? GetEmployeesByAge(int age, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        var result = new List<Employee>();
        for (int i = 0; i < new Random().Next(50, 100); i++)
        {
            var employee = _employeeFactory.CreateGenericEmployee();
            if (equalTo)
                employee.Age = age;
            else if (greaterThan && !lessThan)
                employee.Age = new Random().Next(age + 1, age + 15);
            else if (lessThan && !greaterThan)
                employee.Age = new Random().Next(age - 1, age - 15);
            else
                throw new ArgumentException($"Invalid Parameters; {nameof(age)} must be an int, " +
                    $"{nameof(greaterThan)} and {nameof(lessThan)} cannot be the same value");

            result.Add(employee);
        }
        return Task.Run(() => result.AsQueryable());
    }

    public Task<IQueryable<Employee>>? GetEmployeesByHireDate(DateTime hireDate, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        var result = new List<Employee>();
        for (int i = 0; i < new Random().Next(50, 100); i++)
        {
            var employee = _employeeFactory.CreateGenericEmployee();
            var randomHighYear = new Random().Next(hireDate.Year + 1, hireDate.Year + 10);
            var randomLowYear = 0;

            if (hireDate.Year > DateTime.MinValue.Year + 10)
                randomLowYear = hireDate.Year - new Random().Next(1, 10);
            else
                randomLowYear = DateTime.MinValue.Year;

            if (equalTo)
                employee.HireDate = hireDate;
            else if (greaterThan && !lessThan)
                employee.HireDate = new DateTime(randomHighYear, 1, 1);
            else if (lessThan && !greaterThan)
                employee.HireDate = new DateTime(randomLowYear, 1, 1);
            else
                throw new ArgumentException($"Invalid Parameters; {nameof(hireDate)} must be in date format, " +
                    $"{nameof(greaterThan)} and {nameof(lessThan)} cannot both be set to true");

            result.Add(employee);
        }
        return Task.Run(() => result.AsQueryable());
    }

    public Task<IQueryable<Employee>>? GetEmployeesByName(string? firstName = null, string? lastName = null)
    {
        var result = new List<Employee>();
        for (int i = 0; i < new Random().Next(50, 100); i++)
        {
            var employee = _employeeFactory.CreateGenericEmployee();

            if (firstName is not null)
                employee.FirstName = firstName += employee.FirstName;
            if (lastName is not null)
                employee.LastName = firstName += employee.LastName;

            result.Add(employee);
        }
        return Task.Run(() => result.AsQueryable());
    }

    public Task<IQueryable<Employee>>? GetEmployeesBySalary(decimal salary, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        var result = new List<Employee>();
        for (int i = 0; i < new Random().Next(50, 100); i++)
        {
            var employee = _employeeFactory.CreateGenericEmployee();
            if (equalTo)
                employee.Salary = salary;
            else if (greaterThan && !lessThan)
                employee.Salary = new Random().Next((int)salary + 1000, (int)salary + 15000);
            else if (lessThan && !greaterThan)
                employee.Salary = new Random().Next((int)salary - 1000, (int)salary - 15000);
            else
                throw new ArgumentException($"Invalid Parameters; {nameof(salary)} must be a number, " +
                    $"{nameof(greaterThan)} and {nameof(lessThan)} cannot be the same value");

            result.Add(employee);
        }
        return Task.Run(() => result.AsQueryable());
    }

    public Task<IQueryable<Employee>>? GetEmployeesByTitle(string title)
    {
        var result = new List<Employee>();
        for (int i = 0; i < new Random().Next(50, 100); i++)
        {
            var employee = _employeeFactory.CreateGenericEmployee();
            employee.Title = title;
            result.Add(employee);
        }

        return Task.Run(() => result.AsQueryable());
    }

    public Task<int> InsertEmployee(Employee employee)
    {
        return Task.Run(() => {
            return new Random().Next(50, 100);
        });
    }

    public Task<int> UpdateEmployee(Employee employee)
    {
        return Task.Run(() => {
            return new Random().Next(50, 100);
        });
    }

    public Task<int> DeleteEmployeeRecord(int databaseId)
    {
        return Task.Run(() => {
            return new Random().Next(50, 100);
        });
    }
}
