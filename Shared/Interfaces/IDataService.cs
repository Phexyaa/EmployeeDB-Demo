using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces;
public interface IDataService
{
    public Employee? GetEmployeeByEmployeeId(Guid employeeId);
    public Employee? GetEmployeeByDatabaseId(int databaseId);
    public IQueryable<Employee>? GetAllEmployees();
    public IQueryable<Employee>? GetAllActiveEmployees();
    public IQueryable<Employee>? GetAllInactiveEmployees();
    public IQueryable<Employee>? GetEmployeesByAge(int age, bool greaterThan, bool lessThan, bool equalTo);
    public IQueryable<Employee>? GetEmployeesByHireDate(DateTime hireDate, bool greaterThan, bool lessThan, bool equalTo);
    public IQueryable<Employee>? GetEmployeesByName(string firstName, string lastName);
    public IQueryable<Employee>? GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo);
    public IQueryable<Employee>? GetEmployeesByTitle(string title);
    public int DeleteEmployeeRecord(int databaseId);
    public int InsertEmployee(Employee employee);
    public int UpdateEmployee(Employee employee);

}
