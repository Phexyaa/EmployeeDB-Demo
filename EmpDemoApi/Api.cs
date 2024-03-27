using API.Data;
using Shared.Models;

namespace EmpDemoApi;

public static class Api
{

    public static void ConfigureAPI(this WebApplication app)
    {
        app.MapGet("/GetAllEmployees", GetAllEmployees).WithName("GetAllEmployees").WithOpenApi();
        app.MapGet("/GetAllActiveEmployees", GetAllActiveEmployees).WithName("GetAllActiveEmployees").WithOpenApi();
        app.MapGet("/GetAllInActiveEmployees", GetAllInactiveEmployees).WithName("GetAllInActiveEmployees").WithOpenApi();
        app.MapGet("/GetEmployeeByEmployeeId", GetEmployeeByEmployeeId).WithName("GetEmployeeByEmployeeId").WithOpenApi();
        app.MapGet("/GetEmployeeByDatabaseId", GetEmployeeByDatabaseId).WithName("GetEmployeeByDatabaseId").WithOpenApi();
        app.MapGet("/GetEmployeesByAge", GetEmployeesByAge).WithName("GetEmployeeByDatabaseId").WithOpenApi();
        app.MapGet("/GetEmployeesByHireDate", GetEmployeesByHireDate).WithName("GetEmployeesByHireDate").WithOpenApi();
        app.MapGet("/GetEmployeesByName", GetEmployeesByName).WithName("GetEmployeesByName").WithOpenApi();
        app.MapGet("/GetEmployeesBySalary", GetEmployeesBySalary).WithName("GetEmployeesBySalary").WithOpenApi();
        app.MapGet("/GetEmployeesByTitle", GetEmployeesByTitle).WithName("GetEmployeesByTitle").WithOpenApi();
        app.MapGet("/InsertEmployee", InsertEmployee).WithName("InsertEmployee").WithOpenApi();
        app.MapGet("/UpdateEmployee", UpdateEmployee).WithName("UpdateEmployee").WithOpenApi();

        app.MapGet("/GetStatus", ConnectionTest).WithName("ConnectionTest").WithOpenApi();
    }

    private static bool ConnectionTest()
    {
        return true;
    }
    private static IQueryable<Employee>? GetAllActiveEmployees(IDataAccess data)
    {
        return data.GetAllActiveEmployees();
    }
    private static IQueryable<Employee>? GetAllEmployees(IDataAccess data)
    {
        return data.GetAllEmployees();
    }
    private static IQueryable<Employee>? GetAllInactiveEmployees(IDataAccess data)
    {
        return data.GetAllInactiveEmployees();
    }
    private static IQueryable<Employee>? GetEmployeeByEmployeeId(IDataAccess data, Guid employeeId)
    {
        return data.GetEmployeeByEmployeeId(employeeId);
    }
    private static IQueryable<Employee>? GetEmployeeByDatabaseId(IDataAccess data, int databaseId)
    {
        return data.GetEmployeeByDatabaseId(databaseId);
    }
    private static IQueryable<Employee>? GetEmployeesByAge(IDataAccess data, int age, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        return data.GetEmployeesByAge(age, greaterThan, lessThan, equalTo);
    }
    private static IQueryable<Employee>? GetEmployeesByHireDate(IDataAccess data, DateTime hireDate, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        return data.GetEmployeesByHireDate(hireDate, greaterThan, lessThan, equalTo);
    }
    private static IQueryable<Employee>? GetEmployeesByName(IDataAccess data, string firstName, string lastName)
    {
        return data.GetEmployeesByName(firstName, lastName);

    }
    private static IQueryable<Employee>? GetEmployeesBySalary(IDataAccess data, decimal salary, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        return data.GetEmployeesBySalary(salary, greaterThan, lessThan, equalTo);
    }
    private static IQueryable<Employee>? GetEmployeesByTitle(IDataAccess data, string title)
    {
        return data.GetEmployeesByTitle(title);
    }
    private static int InsertEmployee(IDataAccess data, Employee employee)
    {
        return data.InsertEmployee(employee);
    }
    private static int UpdateEmployee(IDataAccess data, Employee employee)
    {
        return data.UpdateEmployee(employee);
    }
}
