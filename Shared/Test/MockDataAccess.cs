using Shared.Interfaces;
using Shared.Models;
using Shared.Utility;
using System.Linq.Expressions;

namespace Shared.Test;

public class MockDataAccess : IDataService
{
    private readonly IEmployeeFactory _employeeFactory;
    private IQueryable<Employee> employees = new List<Employee>().AsQueryable();
    public MockDataAccess(IEmployeeFactory employeeFactory)
    {
        _employeeFactory = employeeFactory;
    }


    public Task<Employee> GetEmployeeByDatabaseId(int databaseId)
    {
        var employee = _employeeFactory.CreateGenericEmployee() ?? new Employee();
        employee.Id = databaseId;
        return Task.Run(()=> employee);
    }

    public Task<Employee> GetEmployeeByEmployeeId(Guid id)
    {
        var employee = _employeeFactory.CreateGenericEmployee() ?? new Employee();
        employee.EmployeeId = id;
        return Task.Run(() => employee);
    }
    private IQueryable<Employee> GenerateEmployees() {
        var result = new List<Employee>();
        for (int i = 0; i < new Random().Next(50, 100); i++)
        {
            var employee = _employeeFactory.CreateGenericEmployee() ?? new Employee();
            employee.IsActive = true;
            result.Add(employee);
        }
        return result.AsQueryable();
    }
    public Task<IQueryable<Employee>> GetAllActiveEmployees()
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.IsActive == true));
    }

    public Task<IQueryable<Employee>> GetAllEmployees()
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees);
    }

    public Task<IQueryable<Employee>> GetAllInactiveEmployees()
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.IsActive == false));
    }

    public Task<IQueryable<Employee>> GetEmployeesByAge(int age, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        if (equalTo)
            return Task.FromResult(employees.Where(e => e.Age == age));
        else if (greaterThan && !lessThan)
            return Task.FromResult(employees.Where(e => e.Age > age));
        else if (lessThan && !greaterThan)
            return Task.FromResult(employees.Where(e => e.Age < age));
        else
            throw new ArgumentException($"Invalid Parameters; {nameof(age)} must be an int, " +
                $"{nameof(greaterThan)} and {nameof(lessThan)} cannot be the same value");
    }

    public Task<IQueryable<Employee>> GetEmployeesByHireDate(DateTime hireDate, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        var employee = _employeeFactory.CreateGenericEmployee();
        var randomHighYear = new Random().Next(hireDate.Year + 1, hireDate.Year + 10);
        var randomLowYear = 0;

        if (hireDate.Year > DateTime.MinValue.Year + 10)
            randomLowYear = hireDate.Year - new Random().Next(1, 10);
        else
            randomLowYear = DateTime.MinValue.Year;

        if (equalTo)
            return Task.FromResult(employees.Where(e => e.HireDate == hireDate));
        else if (greaterThan && !lessThan)
            return Task.FromResult(employees.Where(e => e.HireDate > hireDate));
        else if (lessThan && !greaterThan)
            return Task.FromResult(employees.Where(e => e.HireDate < hireDate));
        else
            throw new ArgumentException($"Invalid Parameters; {nameof(hireDate)} must be in date format, " +
                $"{nameof(greaterThan)} and {nameof(lessThan)} cannot both be set to true");
    }

    public Task<IQueryable<Employee>> GetEmployeesByFirstName(string firstName)
    {
        firstName = firstName.ToLower();
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e=> e.FirstName !=null && e.FirstName.ToLower().Contains(firstName)));
    }
    public Task<IQueryable<Employee>> GetEmployeesByLastName(string lastName)
    {
        lastName = lastName.ToLower();
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.FirstName != null && e.FirstName.ToLower().Contains(lastName)));
    }

    public Task<IQueryable<Employee>> GetEmployeesBySalary(decimal salary, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        if (equalTo)
            return Task.FromResult(employees.Where(e => e.Salary == salary));
        else if (greaterThan && !lessThan)
            return Task.FromResult(employees.Where(e => e.Salary > salary));
        else if (lessThan && !greaterThan)
            return Task.FromResult(employees.Where(e => e.Salary < salary));
        else
            throw new ArgumentException($"Invalid Parameters; {nameof(salary)} must be a number, " +
                $"{nameof(greaterThan)} and {nameof(lessThan)} cannot be the same value");
    }

    public Task<IQueryable<Employee>> GetEmployeesByTitle(string title)
    {
        if (employees.Count() == 0)
            employees = GenerateEmployees();

        return Task.FromResult(employees.Where(e => e.Title !=null && e.Title.Contains(title)));
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
