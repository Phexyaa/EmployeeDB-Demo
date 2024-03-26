using Shared.Models;
using Shared.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Mock
{
    class MockApi : IApiService
    {
        private readonly IEmployeeFactory _employeeFactory;
        public MockApi(IEmployeeFactory employeeFactory)
        {
            _employeeFactory = employeeFactory;
        }
        public List<Person> GetEmployees()
        {
            var list = new List<Person>();
            var rando = new Random().Next(1, 26);
            for (int i = 0; i < rando; i++)
            {
                list.Add(_employeeFactory.CreateEmployee("","",0,"",DateTime.Now,0));
            }
            return list;
        }

        public bool GetConnectionStatus()
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
    }
}
