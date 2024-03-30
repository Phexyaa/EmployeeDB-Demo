using Shared.Interfaces;
using Shared.Models;
using Shared.Utility;

namespace Shared.Test;

public class MockDataAccess : IDataService
{
    private readonly IEmployeeFactory _employeeFactory;
    private List<Employee> employees = new List<Employee>();
    public MockDataAccess(IEmployeeFactory employeeFactory)
    {
        _employeeFactory = employeeFactory;
    }
    private List<Employee> GenerateEmployees()
    {
        var result = new List<Employee>();
        for (int i = 0; i < new Random().Next(50, 100); i++)
        {
            var employee = _employeeFactory.CreateGenericEmployee() ?? new Employee();
            employee.IsActive = true;
            result.Add(employee);
        }
        return result;
    }

    public Task<List<Employee>> GetEmployeeByDatabaseId(int databaseId)
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.Id == databaseId).ToList());
    }

    public Task<List<Employee>> GetEmployeeByEmployeeId(string employeeId)
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.EmployeeId.Contains(employeeId)).ToList());
    }
    public Task<List<Employee>> GetAllActiveEmployees()
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.IsActive == true).ToList());
    }

    public Task<List<Employee>> GetAllEmployees()
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees);
    }

    public Task<List<Employee>> GetAllInactiveEmployees()
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.IsActive == false).ToList());
    }

    public Task<List<Employee>> GetEmployeesByAge(int age, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        if (equalTo)
            return Task.FromResult(employees.Where(e => e.Age == age).ToList());
        else if (greaterThan && !lessThan)
            return Task.FromResult(employees.Where(e => e.Age > age).ToList());
        else if (lessThan && !greaterThan)
            return Task.FromResult(employees.Where(e => e.Age < age).ToList());
        else
            throw new ArgumentException($"Invalid Parameters; {nameof(age)} must be an int, " +
                $"{nameof(greaterThan)} and {nameof(lessThan)} cannot be the same value");
    }

    public Task<List<Employee>> GetEmployeesByHireDate(string hireDateString, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();
        DateTime.TryParse(hireDateString, out DateTime hireDate);
        var employee = _employeeFactory.CreateGenericEmployee();
        var randomHighYear = new Random().Next(hireDate.Year + 1, hireDate.Year + 10);
        var randomLowYear = 0;

        if (hireDate.Year > DateTime.MinValue.Year + 10)
            randomLowYear = hireDate.Year - new Random().Next(1, 10);
        else
            randomLowYear = DateTime.MinValue.Year;

        if (equalTo)
            return Task.FromResult(employees.Where(e => e.HireDate == hireDate).ToList());
        else if (greaterThan && !lessThan)
            return Task.FromResult(employees.Where(e => e.HireDate > hireDate).ToList());
        else if (lessThan && !greaterThan)
            return Task.FromResult(employees.Where(e => e.HireDate < hireDate).ToList());
        else
            throw new ArgumentException($"Invalid Parameters; {nameof(hireDate)} must be in date format, " +
                $"{nameof(greaterThan)} and {nameof(lessThan)} cannot both be set to true");
    }

    public Task<List<Employee>> GetEmployeesByFirstName(string firstName)
    {
        firstName = firstName.ToLower();
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.FirstName != null && e.FirstName.ToLower().Contains(firstName)).ToList());
    }
    public Task<List<Employee>> GetEmployeesByLastName(string lastName)
    {
        lastName = lastName.ToLower();
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.LastName != null && e.LastName.ToLower().Contains(lastName)).ToList());
    }

    public Task<List<Employee>> GetEmployeesBySalary(decimal salary, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        if (equalTo)
            return Task.FromResult(employees.Where(e => e.Salary == salary).ToList());
        else if (greaterThan && !lessThan)
            return Task.FromResult(employees.Where(e => e.Salary > salary).ToList());
        else if (lessThan && !greaterThan)
            return Task.FromResult(employees.Where(e => e.Salary < salary).ToList());
        else
            throw new ArgumentException($"Invalid Parameters; {nameof(salary)} must be a number, " +
                $"{nameof(greaterThan)} and {nameof(lessThan)} cannot be the same value");
    }

    public Task<List<Employee>> GetEmployeesByTitle(string title)
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.Title != null && e.Title.Contains(title)).ToList());
    }

    public Task<int> InsertEmployee(Employee employee)
    {
        employees.Add(employee);
        return Task.Run(() =>
        {
            return new Random().Next(50, 100);
        });
    }

    public Task<int> UpdateEmployee(Employee employee)
    {
        var existingRecord = employees.Find(e => e.EmployeeId == employee.EmployeeId);
        if(existingRecord != null)
        {
            employees[employees.IndexOf(existingRecord)] = employee;
            return Task.Run(() => { return 1; });
        }
        else
            throw new ArgumentOutOfRangeException(nameof(employee), $"{employee.EmployeeId} was not found in existing dataset.");
    }

    public Task<int> DeleteEmployeeRecord(int databaseId)
    {
        return Task.Run(() =>
        {
            return new Random().Next(50, 100);
        });
    }
}
