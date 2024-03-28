using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared.Models;

namespace EmpDemoApi;

public static class Api
{
    public static void ConfigureAPI(this WebApplication app)
    {
        app.MapGet("/GetAllEmployees", GetAllEmployees).WithName("GetAllEmployees").WithOpenApi();
        app.MapGet("/GetAllActiveEmployees{isActive}", GetAllActiveEmployees).WithName("GetAllActiveEmployees").WithOpenApi();
        app.MapGet("/GetAllInactiveEmployees{isActive}", GetAllInactiveEmployees).WithName("GetAllInactiveEmployees").WithOpenApi();
        app.MapGet("/GetEmployeeByEmployeeId{employeeId}", GetEmployeeByEmployeeId).WithName("GetEmployeeByEmployeeId").WithOpenApi();
        app.MapGet("/GetEmployeeByDatabaseId{databaseId}", GetEmployeeByDatabaseId).WithName("GetEmployeeByDatabaseId").WithOpenApi();
        app.MapGet("/GetEmployeesByAge{age}/{greaterThan}/{lessThan}/{equalTo}", GetEmployeesByAge).WithName("GetEmployeesByAge").WithOpenApi();
        app.MapGet("/GetEmployeesByHireDate{hireDate}/{greaterThan}/{lessThan}/{equalTo}", GetEmployeesByHireDate).WithName("GetEmployeesByHireDate").WithOpenApi();
        app.MapGet("/GetEmployeesByName{firstName}/{lastName}", GetEmployeesByName).WithName("GetEmployeesByName").WithOpenApi();
        app.MapGet("/GetEmployeesBySalary{salary}/{greaterThan}/{lessThan}/{equalTo}", GetEmployeesBySalary).WithName("GetEmployeesBySalary").WithOpenApi();
        app.MapGet("/GetEmployeesByTitle{title}", GetEmployeesByTitle).WithName("GetEmployeesByTitle").WithOpenApi();
        app.MapPut("/InsertEmployee", InsertEmployee).WithName("InsertEmployee").WithOpenApi();
        app.MapPost("/UpdateEmployee", UpdateEmployee).WithName("UpdateEmployee").WithOpenApi();

        app.MapGet("/GetStatus", ConnectionTest).WithName("ConnectionTest").WithOpenApi();
    }

    private static bool ConnectionTest()
    {
        return true;
    }
    private static IQueryable<Employee>? GetAllActiveEmployees([FromServices] IDataAccess data)
    {
        return data.GetAllActiveEmployees();
    }
    private static IQueryable<Employee>? GetAllEmployees([FromServices] IDataAccess data)
    {
        return data.GetAllEmployees();
    }
    private static IQueryable<Employee>? GetAllInactiveEmployees([FromServices] IDataAccess data)
    {
        return data.GetAllInactiveEmployees();
    }
    private static Employee? GetEmployeeByDatabaseId([FromServices] IDataAccess data,
                                                                 [FromRoute] int databaseId)
    {
        return data.GetEmployeeByDatabaseId(databaseId);
    }
    private static Employee? GetEmployeeByEmployeeId([FromServices] IDataAccess data,
                                                                 [FromRoute] Guid employeeId)
    {
        return data.GetEmployeeByEmployeeId(employeeId);
    }
    private static IQueryable<Employee>? GetEmployeesByAge([FromServices] IDataAccess data,
                                                           [FromRoute] int age,
                                                           [FromRoute] bool greaterThan,
                                                           [FromRoute] bool lessThan,
                                                           [FromRoute] bool equalTo)
    {
        return data.GetEmployeesByAge(age, greaterThan, lessThan, equalTo);
    }
    private static IQueryable<Employee>? GetEmployeesByHireDate([FromServices] IDataAccess data,
                                                                [FromRoute] DateTime hireDate,
                                                                [FromRoute] bool greaterThan,
                                                                [FromRoute] bool lessThan,
                                                                [FromRoute] bool equalTo)
    {
        return data.GetEmployeesByHireDate(hireDate, greaterThan, lessThan, equalTo);
    }
    private static IQueryable<Employee>? GetEmployeesByName([FromServices] IDataAccess data,
                                                            [FromRoute] string firstName,
                                                            [FromRoute] string lastName)
    {
        return data.GetEmployeesByName(firstName, lastName);

    }
    private static IQueryable<Employee>? GetEmployeesBySalary([FromServices] IDataAccess data,
                                                              [FromRoute] decimal salary,
                                                              [FromRoute] bool greaterThan,
                                                              [FromRoute] bool lessThan,
                                                              [FromRoute] bool equalTo)
    {
        return data.GetEmployeesBySalary(salary, greaterThan, lessThan, equalTo);
    }
    private static IQueryable<Employee>? GetEmployeesByTitle([FromKeyedServices("D" +
        "ataAccess")] IDataAccess data, [FromRoute] string title)
    {
        return data.GetEmployeesByTitle(title);
    }
    private static int InsertEmployee([FromServices] IDataAccess data,
                                      [FromBody] Employee employee)
    {
        return data.InsertEmployee(employee);
    }
    private static int UpdateEmployee([FromServices] IDataAccess data,
                                      [FromBody] Employee employee)
    {
        return data.UpdateEmployee(employee);
    }
}
