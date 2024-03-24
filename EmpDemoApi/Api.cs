using System.Runtime.CompilerServices;
using Shared.Models;

namespace EmpDemoApi;

public static class Api
{

    public static void ConfigureAPI(this WebApplication app)
    {
        app.MapGet("/GetPeople", GetPeople).WithName("GetPeople").WithOpenApi();
        app.MapGet("/GetStatus", ConnectionTest).WithName("ConnectionTest").WithOpenApi();
    }

    private static IQueryable<Person> GetPeople(IDataAccess data)
    {
        return data.GetPeople();
    }
    private static void ConnectionTest()
    {

    }
}
