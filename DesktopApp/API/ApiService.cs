using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.API;
internal class ApiService : IApiService
{
    public bool ConnectionTest()
    {
        throw new NotImplementedException();
    }
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

    public IQueryable<Employee> GetEmployeesByAge(int age, bool greaterThan, bool lessThan, bool equalTo)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetEmployeesByHireDate(DateTime hireDate, bool greaterThan, bool lessThan, bool equalTo)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetEmployeesByName(string firstName, string lastName)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Employee> GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo)
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
    public int DeleteEmployeeRecord(int databaseId)
    {
        throw new NotImplementedException();
    }
}
