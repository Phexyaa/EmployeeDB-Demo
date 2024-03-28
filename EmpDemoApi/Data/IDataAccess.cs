using Shared.Models;

namespace API.Data;
public interface IDataAccess
{
    int DeleteEmployeeRecord(int databaseId);
    IQueryable<Employee>? GetAllActiveEmployees();
    IQueryable<Employee>? GetAllEmployees();
    IQueryable<Employee>? GetAllInactiveEmployees();
    Employee? GetEmployeeByDatabaseId(int databaseId);
    Employee? GetEmployeeByEmployeeId(Guid id);
    IQueryable<Employee>? GetEmployeesByAge(int age, bool greaterThan = false, bool lessThan = false, bool equalTo = true);
    IQueryable<Employee>? GetEmployeesByHireDate(DateTime hireDate, bool greaterThan = false, bool lessThan = false, bool equalTo = true);
    IQueryable<Employee>? GetEmployeesByName(string? firstName = null, string? lastName = null);
    IQueryable<Employee>? GetEmployeesBySalary(decimal salary, bool greaterThan = false, bool lessThan = false, bool equalTo = true);
    IQueryable<Employee>? GetEmployeesByTitle(string title);
    int InsertEmployee(Employee employee);
    int UpdateEmployee(Employee employee);
}