using Dapper;
using Microsoft.Data.SqlClient;
using Shared.Models;
using System.Data;

namespace EmpDemoApi;

public class DataAccess : IDataAccess
{
    private readonly IConfiguration _config;

    public DataAccess(IConfiguration config)
    {
        _config = config;
    }
    public IQueryable<Person> GetPeople()
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var temp = connection.Query<Person>("SpGetPeople", null, commandType: CommandType.StoredProcedure).AsQueryable();
        return temp;
    }
}
