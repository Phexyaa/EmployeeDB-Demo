using DesktopApp.API;
using Shared.Models;
using Shared.Utility;

namespace DesktopApp.Mock
{
    class MockApi : IApiService
    {
        private readonly IEmployeeFactory _employeeFactory;
        public MockApi(IEmployeeFactory employeeFactory)
        {
            _employeeFactory = employeeFactory;
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
        public IQueryable<Employee> GetAllEmployees()
        {
            var list = new List<Person>();
            var rando = new Random().Next(1, 26);
            for (int i = 0; i < rando; i++)
            {
                list.Add(_employeeFactory.CreateEmployee("", "", 0, "", DateTime.Now, 0));
            }
            return list;
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
    }
}
