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

        public async Task<Employee> GetEmployeeByEmployeeId(Guid employeeId)
        {
            return await _dataAccess.GetEmployeeByEmployeeId(employeeId);
        }

        public async Task<Employee> GetEmployeeByDatabaseId(int databaseId)
        {
            return await _dataAccess.GetEmployeeByDatabaseId(databaseId);
        }

        public async Task<IQueryable<Employee>>? GetAllEmployees()
        {
            return await _dataAccess.GetAllEmployees();
        }

        public async Task<IQueryable<Employee>>? GetAllActiveEmployees()
        {
            return await _dataAccess.GetAllActiveEmployees();
        }

        public async Task<IQueryable<Employee>>? GetAllInactiveEmployees()
        {
            return await _dataAccess.GetAllInactiveEmployees();
        }

        public async Task<IQueryable<Employee>>? GetEmployeesByAge(int age, bool greaterThan, bool lessThan, bool equalTo)
        {
            return await _dataAccess.GetEmployeesByAge(age, greaterThan, lessThan, equalTo);
        }

        public async Task<IQueryable<Employee>>? GetEmployeesByHireDate(DateTime hireDate, bool greaterThan, bool lessThan, bool equalTo)
        {
            return await _dataAccess.GetEmployeesByHireDate(hireDate, greaterThan, lessThan, equalTo);
        }

        public async Task<IQueryable<Employee>>? GetEmployeesByName(string firstName, string lastName)
        {
            return await _dataAccess.GetEmployeesByName(firstName, lastName);
        }

        public async Task<IQueryable<Employee>>? GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo)
        {
            return await _dataAccess.GetEmployeesBySalary(salary, greaterThan, lessThan, equalTo);
        }

        public async Task<IQueryable<Employee>>? GetEmployeesByTitle(string title)
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
