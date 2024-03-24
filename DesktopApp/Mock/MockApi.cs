using DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Mock
{
    class MockApi: IApiService
    {
        public List<Employee> GetEmployees()
        {
           var list = new List<Employee>();
            var rando = new Random().Next(1, 26);
            for(int i = 0; i < rando; i++)
            {
                var employee = new Employee();
                employee.FirstName = new Random().Next(3000, int.MaxValue).ToString();
                employee.LastName = new Random().Next(3000, int.MaxValue).ToString();
                employee.Id = i;
                employee.Age = new Random().Next(1, 101);
                list.Add(employee);
            }
            return list;
        }
    }
}
