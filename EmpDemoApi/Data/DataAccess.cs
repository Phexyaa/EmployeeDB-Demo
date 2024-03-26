using Dapper;
using Microsoft.Data.SqlClient;
using Shared.Enums;
using Shared.Models;
using System.Data;

namespace API.Data;

public class DataAccess : IDataAccess
{
    private readonly IConfiguration _config;

    public DataAccess(IConfiguration config)
    {
        _config = config;
    }
    internal IQueryable<Employee> GetAllEmployees()
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var temp = connection.Query<Employee>("SpGetPeople", null, commandType: CommandType.StoredProcedure).AsQueryable();
        return temp;
    }

}
