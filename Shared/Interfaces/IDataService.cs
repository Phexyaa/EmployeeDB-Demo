using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces;
public interface IDataService
{
    public Task<Employee> GetEmployeeByEmployeeId(Guid employeeId);
    public Task<Employee> GetEmployeeByDatabaseId(int databaseId);
    public  Task<IQueryable<Employee?>> GetAllEmployees();
    public  Task<IQueryable<Employee?>> GetAllActiveEmployees();
    public  Task<IQueryable<Employee?>> GetAllInactiveEmployees();
    public  Task<IQueryable<Employee?>> GetEmployeesByAge(int age, bool greaterThan, bool lessThan, bool equalTo);
    public  Task<IQueryable<Employee?>> GetEmployeesByHireDate(DateTime hireDate, bool greaterThan, bool lessThan, bool equalTo);
    public Task<IQueryable<Employee?>> GetEmployeesByFirstName(string firstName);
    public Task<IQueryable<Employee?>> GetEmployeesByLastName(string lastName);
    public  Task<IQueryable<Employee?>> GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo);
    public  Task<IQueryable<Employee?>> GetEmployeesByTitle(string title);
    public Task<int> DeleteEmployeeRecord(int databaseId);
    public Task<int> InsertEmployee(Employee employee);
    public Task<int> UpdateEmployee(Employee employee);

}
