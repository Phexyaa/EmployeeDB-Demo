﻿using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Shared.Models;

namespace EmpDemoApi;

public static class Api
{
    public static void ConfigureAPI(this WebApplication app)
    {
        app.MapGet("/ConnectionTest", ConnectionTest).WithName("ConnectionTest").WithOpenApi();
        app.MapGet("/GetAllEmployees", GetAllEmployees).WithName("GetAllEmployees").WithOpenApi();
        app.MapGet("/GetAllActiveEmployees", GetAllActiveEmployees).WithName("GetAllActiveEmployees").WithOpenApi();
        app.MapGet("/GetAllInactiveEmployees", GetAllInactiveEmployees).WithName("GetAllInactiveEmployees").WithOpenApi();
        app.MapGet("/GetEmployeeByEmployeeId/{employeeId}", GetEmployeeByEmployeeId).WithName("GetEmployeeByEmployeeId").WithOpenApi();
        app.MapGet("/GetEmployeeByDatabaseId/{databaseId}", GetEmployeeByDatabaseId).WithName("GetEmployeeByDatabaseId").WithOpenApi();
        app.MapGet("/GetEmployeesByAge/{age}/{greaterThan}/{lessThan}/{equalTo}", GetEmployeesByAge).WithName("GetEmployeesByAge").WithOpenApi();
        app.MapGet("/GetEmployeesByHireDate/{hireDate}/{greaterThan}/{lessThan}/{equalTo}", GetEmployeesByHireDate).WithName("GetEmployeesByHireDate").WithOpenApi();
        app.MapGet("/GetEmployeesByFirstName/{firstName}", GetEmployeesByFirstName).WithName("GetEmployeesByFirstName").WithOpenApi();
        app.MapGet("/GetEmployeesByLastName/{lastName}", GetEmployeesByLastName).WithName("GetEmployeesByLastName").WithOpenApi();
        app.MapGet("/GetEmployeesBySalary/{salary}/{greaterThan}/{lessThan}/{equalTo}", GetEmployeesBySalary).WithName("GetEmployeesBySalary").WithOpenApi();
        app.MapGet("/GetEmployeesByTitle/{title}", GetEmployeesByTitle).WithName("GetEmployeesByTitle").WithOpenApi();

        app.MapPut("/InsertEmployee", InsertEmployee).WithName("InsertEmployee").WithOpenApi();

        app.MapPost("/UpdateEmployee", UpdateEmployee).WithName("UpdateEmployee").WithOpenApi();

    }

    private static bool ConnectionTest()
    {
        return true;
    }
    private static async Task<List<Employee>> GetEmployeeByDatabaseId([FromServices] IDataService data,
                                                                 [FromRoute] int databaseId)
    {
        return await data.GetEmployeeByDatabaseId(databaseId);
    }
    private static async Task<List<Employee>> GetEmployeeByEmployeeId([FromServices] IDataService data,
                                                                 [FromRoute] string employeeId)
    {
        return await data.GetEmployeeByEmployeeId(employeeId);
    }
    private static async Task<List<Employee?>> GetAllActiveEmployees([FromServices] IDataService data)
    {
        return await data.GetAllActiveEmployees()!;
    }
    private static async Task<List<Employee?>> GetAllEmployees([FromServices] IDataService data)
    {
        return await data.GetAllEmployees();
    }
    private static async Task<List<Employee?>> GetAllInactiveEmployees([FromServices] IDataService data)
    {
        return await data.GetAllInactiveEmployees()!;
    }
    private static async Task<List<Employee?>> GetEmployeesByAge([FromServices] IDataService data,
                                                           [FromRoute] int age,
                                                           [FromRoute] bool greaterThan,
                                                           [FromRoute] bool lessThan,
                                                           [FromRoute] bool equalTo)
    {
        return await data.GetEmployeesByAge(age, greaterThan, lessThan, equalTo)!;
    }
    private static async Task<List<Employee?>> GetEmployeesByHireDate([FromServices] IDataService data,
                                                                [FromRoute] string hireDate,
                                                                [FromRoute] bool greaterThan,
                                                                [FromRoute] bool lessThan,
                                                                [FromRoute] bool equalTo)
    {
        return await data.GetEmployeesByHireDate(hireDate, greaterThan, lessThan, equalTo)!;
    }
    private static async Task<List<Employee?>> GetEmployeesByFirstName([FromServices] IDataService data,
                                                            [FromRoute] string firstName)
    {
        return await data.GetEmployeesByFirstName(firstName)!;

    }
    private static async Task<List<Employee?>> GetEmployeesByLastName([FromServices] IDataService data,
                                                            [FromRoute] string lastName)
    {
        return await data.GetEmployeesByLastName(lastName)!;

    }
    private static async Task<List<Employee?>> GetEmployeesBySalary([FromServices] IDataService data,
                                                              [FromRoute] decimal salary,
                                                              [FromRoute] bool greaterThan,
                                                              [FromRoute] bool lessThan,
                                                              [FromRoute] bool equalTo)
    {
        return await data.GetEmployeesBySalary(salary, greaterThan, lessThan, equalTo)!;
    }
    private static async Task<List<Employee?>> GetEmployeesByTitle([FromKeyedServices("D" +
        "ataAccess")] IDataService data, [FromRoute] string title)
    {
        return await data.GetEmployeesByTitle(title)!;
    }
    private static async Task<int>? InsertEmployee([FromServices] IDataService data,
                                      [FromBody] Employee employee)
    {
        return await data.InsertEmployee(employee);
    }
    private static async Task<int>? UpdateEmployee([FromServices] IDataService data,
                                      [FromBody] Employee employee)
    {
        return await data.UpdateEmployee(employee);
    }
}
