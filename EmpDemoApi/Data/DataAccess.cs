using Azure;
using Dapper;
using Microsoft.Data.SqlClient;
using Shared.Enums;
using Shared.Interfaces;
using Shared.Models;
using System.Data;

namespace API.Data;

public class DataAccess : IDataService
{
    private readonly IConfiguration _config;

    public DataAccess(IConfiguration config) => _config = config;
    public async Task<Employee?> GetEmployeeByDatabaseId(int databaseId)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeeByDatabaseId", databaseId, null, commandType: CommandType.StoredProcedure);;
        var result = response.FirstOrDefault();
        return result;
    }
    public async Task<Employee?> GetEmployeeByEmployeeId(Guid id)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByEmployeeId", id, null, commandType: CommandType.StoredProcedure);;
        var result = response.FirstOrDefault();
        return result;
    }
    public async Task<IQueryable<Employee?>> GetAllActiveEmployees()
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
       var response = await connection.QueryAsync<Employee>("SpGetAllActiveEmployees", true, null, commandType: CommandType.StoredProcedure);;
        var result = response.AsQueryable();
        return result;
    }
    public async Task<IQueryable<Employee?>> GetAllEmployees()
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetAllEmployees", null, commandType: CommandType.StoredProcedure);
        var result = response.AsQueryable();
        return result;
    }
    public async Task<IQueryable<Employee?>> GetAllInactiveEmployees()
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetAllInactiveEmployees", false, null, commandType: CommandType.StoredProcedure);
        var result = response.AsQueryable();
        return result;
    }
    public async Task<IQueryable<Employee?>> GetEmployeesByAge(int age, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByAge", age, null, commandType: CommandType.StoredProcedure);
        var result = response.AsQueryable();
        return result;
    }
    public async Task<IQueryable<Employee?>> GetEmployeesByHireDate(DateTime hireDate, bool greaterThan, bool lessThan, bool equalTo = true)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByHireDate", hireDate.ToShortDateString(), null, commandType: CommandType.StoredProcedure);
        var result = response.AsQueryable();
        return result;
    }
    public async Task<IQueryable<Employee?>> GetEmployeesByFirstName(string firstName)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByFirstName", firstName, null, commandType: CommandType.StoredProcedure);
        var result = response.AsQueryable();
        return result;
    }
    public async Task<IQueryable<Employee?>> GetEmployeesByLastName(string lastName)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByLastName", lastName, null, commandType: CommandType.StoredProcedure);
        var result = response.AsQueryable();
        return result;
    }
    public async Task<IQueryable<Employee?>> GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo = true)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesBySalary", salary, null, commandType: CommandType.StoredProcedure);
        var result = response.AsQueryable();
        return result;
    }
    public async Task<IQueryable<Employee?>> GetEmployeesByTitle(string title)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByTitle", title, null, commandType: CommandType.StoredProcedure);
        var result = response.AsQueryable();
        return result;
    }
    public async Task<int> InsertEmployee(Employee employee)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = await connection.ExecuteAsync("SpInsertEmployee", employee, null, commandType: CommandType.StoredProcedure);;
        return result;
    }
    public async Task<int> UpdateEmployee(Employee employee)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = await connection.ExecuteAsync("SpUpdateEmployee", employee, null, commandType: CommandType.StoredProcedure);;
        return result;
    }
    public async Task<int> DeleteEmployeeRecord(int databaseId)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = await connection.ExecuteAsync("SpDeleteEmployeeRecord", databaseId, null, commandType: CommandType.StoredProcedure);;
        return result;
    }

}
