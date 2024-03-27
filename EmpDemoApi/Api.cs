using API.Data;
using Shared.Models;

namespace EmpDemoApi;

public static class Api
{

    public static void ConfigureAPI(this WebApplication app)
    {
        app.MapGet("/GetPeople", GetPeople).WithName("GetPeople").WithOpenApi();
        app.MapGet("/GetStatus", ConnectionTest).WithName("ConnectionTest").WithOpenApi();
    }

    private static IQueryable<Employee> GetPeople(IDataAccess data)
    {
        return data.GetAllEmployees();
    }
    private static bool ConnectionTest()
    {
        return true;
    }
}
