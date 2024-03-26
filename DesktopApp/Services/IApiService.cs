using Shared.Models;

namespace DesktopApp
{
    interface IApiService
    {
        public List<Person> GetEmployees();
        public bool GetConnectionStatus();
    }
}
