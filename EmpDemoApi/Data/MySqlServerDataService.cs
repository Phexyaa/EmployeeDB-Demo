﻿using Dapper;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using Shared.Interfaces;
using Shared.Models;
using System.Data;

namespace API.Data;

public class MySqlDataService : IDataService
{
    private readonly IConfiguration _config;

    public MySqlDataService(IConfiguration config) => _config = config;
    public async Task<List<Employee>> GetEmployeeByDatabaseId(int databaseId)
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeeByDatabaseId", databaseId, null, commandType: CommandType.StoredProcedure);;
        var result = response.ToList();
        return result;
    }
    public async Task<List<Employee>> GetEmployeeByEmployeeId(string id)
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByEmployeeId", id, null, commandType: CommandType.StoredProcedure);;
        var result = response.ToList();
        return result;
    }
    public async Task<List<Employee?>> GetAllActiveEmployees()
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
       var response = await connection.QueryAsync<Employee>("SpGetAllActiveEmployees", true, null, commandType: CommandType.StoredProcedure);;
        var result = response.ToList();
        return result;
    }
    public async Task<List<Employee?>> GetAllEmployees()
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetAllEmployees", null, commandType: CommandType.StoredProcedure);
        var result = response.ToList();
        return result;
    }
    public async Task<List<Employee?>> GetAllInactiveEmployees()
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetAllInactiveEmployees", false, null, commandType: CommandType.StoredProcedure);
        var result = response.ToList();
        return result;
    }
    public async Task<List<Employee?>> GetEmployeesByAge(int age, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByAge", age, null, commandType: CommandType.StoredProcedure);
        var result = response.ToList();
        return result;
    }
    public async Task<List<Employee?>> GetEmployeesByHireDate(string hireDate, bool greaterThan, bool lessThan, bool equalTo = true)
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByHireDate", hireDate, null, commandType: CommandType.StoredProcedure);
        var result = response.ToList();
        return result;
    }
    public async Task<List<Employee?>> GetEmployeesByFirstName(string firstName)
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByFirstName", firstName, null, commandType: CommandType.StoredProcedure);
        var result = response.ToList();
        return result;
    }
    public async Task<List<Employee?>> GetEmployeesByLastName(string lastName)
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByLastName", lastName, null, commandType: CommandType.StoredProcedure);
        var result = response.ToList();
        return result;
    }
    public async Task<List<Employee?>> GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo = true)
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesBySalary", salary, null, commandType: CommandType.StoredProcedure);
        var result = response.ToList();
        return result;
    }
    public async Task<List<Employee?>> GetEmployeesByTitle(string title)
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var response = await connection.QueryAsync<Employee>("SpGetEmployeesByTitle", title, null, commandType: CommandType.StoredProcedure);
        var result = response.ToList();
        return result;
    }
    public async Task<int> InsertEmployee(Employee employee)
    {
        var parameters = new DynamicParameters(employee);
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var result = await connection.ExecuteAsync("SpInsertEmployee", parameters, null, commandType: CommandType.StoredProcedure);;
        return result;
    }
    public async Task<int> UpdateEmployee(Employee employee)
    {
        try
        {
            var parameters = new DynamicParameters(employee);
            using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
            var result = await connection.ExecuteAsync("SpUpdateEmployee", parameters, null, commandType: CommandType.StoredProcedure); ;
            return result;
        }
        catch (Exception e)
        {

            throw;
        }
    }
    public async Task<int> DeleteEmployeeRecord(int databaseId)
    {       
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString("Default"));
        var result = await connection.ExecuteAsync("SpDeleteEmployeeRecord", databaseId, null, commandType: CommandType.StoredProcedure);;
        return result;
    }

}
