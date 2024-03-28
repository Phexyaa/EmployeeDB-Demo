using Shared.Interfaces;
using Shared.Models;
using Shared.Utility;

namespace Shared.Test
{
    public class MockApi : IApiService
    {
        private readonly MockDataAccess _dataAccess;
        public MockApi(IEmployeeFactory employeeFactory)
        {
            _dataAccess = new MockDataAccess(employeeFactory);
        }
        public bool ConnectionTest()
        {
            var coinFlip = new Random().Next(0, 2);
            switch (coinFlip)
            {
                case 0:
                    return false;
                case 1:
                    return true;
                default:
                    return false;
            }

        }

        public Employee? GetEmployeeByEmployeeId(Guid employeeId)
        {
            return _dataAccess.GetEmployeeByEmployeeId(employeeId);
        }

        public Employee? GetEmployeeByDatabaseId(int databaseId)
        {
            return _dataAccess.GetEmployeeByDatabaseId(databaseId);
        }

        public IQueryable<Employee>? GetAllEmployees()
        {
            return _dataAccess.GetAllEmployees();
        }

        public IQueryable<Employee>? GetAllActiveEmployees()
        {
            return _dataAccess.GetAllActiveEmployees();
        }

        public IQueryable<Employee>? GetAllInactiveEmployees()
        {
            return _dataAccess.GetAllInactiveEmployees();
        }

        public IQueryable<Employee>? GetEmployeesByAge(int age, bool greaterThan, bool lessThan, bool equalTo)
        {
            return _dataAccess.GetEmployeesByAge( age, greaterThan, lessThan, equalTo);
        }

        public IQueryable<Employee>? GetEmployeesByHireDate(DateTime hireDate, bool greaterThan, bool lessThan, bool equalTo)
        {
            return _dataAccess.GetEmployeesByHireDate(hireDate, greaterThan, lessThan, equalTo);
        }

        public IQueryable<Employee>? GetEmployeesByName(string firstName, string lastName)
        {
            return _dataAccess.GetEmployeesByName(firstName, lastName);
        }

        public IQueryable<Employee>? GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo)
        {
            return _dataAccess.GetEmployeesBySalary(salary, greaterThan, lessThan, equalTo);
        }

        public IQueryable<Employee>? GetEmployeesByTitle(string title)
        {
            return _dataAccess.GetEmployeesByTitle(title);
        }

        public int DeleteEmployeeRecord(int databaseId)
        {
            return _dataAccess.DeleteEmployeeRecord(databaseId);
        }

        public int InsertEmployee(Employee employee)
        {
            return _dataAccess.InsertEmployee(employee);
        }

        public int UpdateEmployee(Employee employee)
        {
            return _dataAccess.UpdateEmployee(employee);
        }
    }
}
