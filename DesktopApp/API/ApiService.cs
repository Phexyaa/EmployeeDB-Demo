using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.API;
internal class ApiService : IApiService
{
    public IQueryable<Employee> GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetAllActiveEmployees()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetAllInactiveEmployees()
    {
        throw new NotImplementedException();
    }

    public Employee GetEmployeeByEmployeeId(Guid employeeId)
    {
        throw new NotImplementedException();
    }

    public Employee GetEmployeeByDatabaseId(int databaseId)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetAllEmployeesByAge(int age, bool greaterThan, bool lessThan, bool equalTo)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetAllEmployeesByHireDate(int age, bool greaterThan, bool lessThan, bool equalTo)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetAllEmployeesByname(string firstName, string lastName)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetAllEmployeesBy(int age, bool greaterThan, bool lessThan, bool equalTo)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetEmployeesByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public int InsertEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public int UpdateEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }
    public bool ConnectionTest()
    {
        throw new NotImplementedException();
    }
}
