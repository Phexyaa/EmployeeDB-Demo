using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    interface IApiService
    {
        public List<Person> GetEmployees();
        public bool GetConnectionStatus();
    }
}
