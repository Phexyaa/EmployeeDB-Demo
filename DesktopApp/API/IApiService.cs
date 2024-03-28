using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.API;
internal interface IApiService
{
    public IQueryable<Employee> GetAllEmployees();
    public IQueryable<Employee> GetAllActiveEmployees();
    public IQueryable<Employee> GetAllInactiveEmployees();
    public Employee GetEmployeeByEmployeeId(Guid employeeId);
    public Employee GetEmployeeByDatabaseId(int databaseId);
    public IQueryable<Employee> GetAllEmployeesByAge(int age, bool greaterThan, bool lessThan, bool equalTo);
    public IQueryable<Employee> GetAllEmployeesByHireDate(int age, bool greaterThan, bool lessThan, bool equalTo);
    public IQueryable<Employee> GetAllEmployeesByname(string firstName, string lastName);
    public IQueryable<Employee> GetAllEmployeesBy(int age, bool greaterThan, bool lessThan, bool equalTo);
    public IQueryable<Employee> GetEmployeesByTitle(string title);
    public int InsertEmployee(Employee employee);
    public int UpdateEmployee(Employee employee);
    public bool ConnectionTest();
}
