using Dapper;
using Microsoft.Data.SqlClient;
using Shared.Enums;
using Shared.Models;
using System.Data;

namespace API.Data;

public class DataAccess : IDataAccess
{
    private readonly IConfiguration _config;

    public DataAccess(IConfiguration config) => _config = config;
    public IQueryable<Employee>? GetAllActiveEmployees()
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Query<Employee>("SpGetAllActiveEmployees", true, null, commandType: CommandType.StoredProcedure).AsQueryable();
        return result;
    }
    public IQueryable<Employee>? GetAllEmployees()
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Query<Employee>("SpGetAllEmployees", null, commandType: CommandType.StoredProcedure).AsQueryable();
        return result;
    }
    public IQueryable<Employee>? GetAllInactiveEmployees()
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Query<Employee>("SpGetAllInactiveEmployees", false, null, commandType: CommandType.StoredProcedure).AsQueryable();
        return result;
    }
    public Employee? GetEmployeeByEmployeeId(Guid id)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Query<Employee>("SpGetEmployeesByEmployeeId", id, null, commandType: CommandType.StoredProcedure).FirstOrDefault();
        return result;
    }
    public Employee? GetEmployeeByDatabaseId(int databaseId)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Query<Employee>("SpGetEmployeeById", databaseId, null, commandType: CommandType.StoredProcedure).FirstOrDefault();
        return result;
    }
    public IQueryable<Employee>? GetEmployeesByAge(int age, bool greaterThan = false, bool lessThan = false, bool equalTo = true)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Query<Employee>("SpGetEmployeesByAge", age, null, commandType: CommandType.StoredProcedure).AsQueryable();
        return result;
    }
    public IQueryable<Employee>? GetEmployeesByHireDate(DateTime hireDate, bool greaterThan, bool lessThan, bool equalTo = true)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Query<Employee>("SpGetEmployeesByHireDate", hireDate.ToShortDateString(), null, commandType: CommandType.StoredProcedure).AsQueryable();
        return result;
    }
    public IQueryable<Employee>? GetEmployeesByName(string? firstName = null, string? lastName = null)
    {
        var parameters = new string?[] { firstName, lastName };
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Query<Employee>("SpGetEmployeesByName", parameters, null, commandType: CommandType.StoredProcedure).AsQueryable();
        return result;
    }
    public IQueryable<Employee>? GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo = true)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Query<Employee>("SpGetEmployeesBySalary", salary, null, commandType: CommandType.StoredProcedure).AsQueryable();
        return result;
    }
    public IQueryable<Employee>? GetEmployeesByTitle(string title)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Query<Employee>("SpGetEmployeesByTitle", title, null, commandType: CommandType.StoredProcedure).AsQueryable();
        return result;
    }
    public int InsertEmployee(Employee employee)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Execute("SpInsertEmployee", employee, null, commandType: CommandType.StoredProcedure);
        return result;
    }
    public int UpdateEmployee(Employee employee)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Execute("SpUpdateEmployee", employee, null, commandType: CommandType.StoredProcedure);
        return result;
    }
    public int DeleteEmployeeRecord(int databaseId)
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var result = connection.Execute("SpDeleteEmployeeRecord", databaseId, null, commandType: CommandType.StoredProcedure);
        return result;
    }
}
