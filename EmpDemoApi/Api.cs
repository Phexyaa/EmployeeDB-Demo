using System.Runtime.CompilerServices;

namespace EmpDemoApi;

public static class Api
{

    public static void ConfigureAPI(this WebApplication app)
    {
        app.MapGet("/GetPeople", GetPeople).WithName("GetPeople").WithOpenApi();
    }

    private static IQueryable<Person> GetPeople(IDataAccess data)
    {
        return data.GetPeople();
    }
}
