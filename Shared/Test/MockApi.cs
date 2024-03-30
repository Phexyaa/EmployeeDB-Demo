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
        public async Task<bool> ConnectionTest()
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

        public async Task<List<Employee>> GetEmployeeByEmployeeId(string employeeId)
        {
            return await _dataAccess.GetEmployeeByEmployeeId(employeeId);
        }

        public async Task<List<Employee>> GetEmployeeByDatabaseId(int databaseId)
        {
            return await _dataAccess.GetEmployeeByDatabaseId(databaseId);
        }

        public async Task<List<Employee?>> GetAllEmployees()
        {
            return await _dataAccess.GetAllEmployees();
        }

        public async Task<List<Employee?>> GetAllActiveEmployees()
        {
            return await _dataAccess.GetAllActiveEmployees();
        }

        public async Task<List<Employee?>> GetAllInactiveEmployees()
        {
            return await _dataAccess.GetAllInactiveEmployees();
        }

        public async Task<List<Employee?>> GetEmployeesByAge(int age, bool greaterThan, bool lessThan, bool equalTo)
        {
            return await _dataAccess.GetEmployeesByAge(age, greaterThan, lessThan, equalTo);
        }

        public async Task<List<Employee?>> GetEmployeesByHireDate(string hireDate, bool greaterThan, bool lessThan, bool equalTo)
        {
            return await _dataAccess.GetEmployeesByHireDate(hireDate, greaterThan, lessThan, equalTo);
        }

        public async Task<List<Employee?>> GetEmployeesByFirstName(string firstName)
        {
            return await _dataAccess.GetEmployeesByFirstName(firstName);
        }
        public async Task<List<Employee?>> GetEmployeesByLastName(string lastName)
        {
            return await _dataAccess.GetEmployeesByLastName(lastName);
        }

        public async Task<List<Employee?>> GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo)
        {
            return await _dataAccess.GetEmployeesBySalary(salary, greaterThan, lessThan, equalTo);
        }

        public async Task<List<Employee?>> GetEmployeesByTitle(string title)
        {
            return await _dataAccess.GetEmployeesByTitle(title);
        }

        public async Task<int> DeleteEmployeeRecord(int databaseId)
        {
            return await _dataAccess.DeleteEmployeeRecord(databaseId);
        }

        public async Task<int> InsertEmployee(Employee employee)
        {
            return await _dataAccess.InsertEmployee(employee);
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            return await _dataAccess.UpdateEmployee(employee);
        }
    }
}
