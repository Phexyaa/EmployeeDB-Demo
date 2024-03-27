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
    public IQueryable<Employee>? GetAllEmployees()
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
        var temp = connection.Query<Employee>("SpGetPeople", null, commandType: CommandType.StoredProcedure).AsQueryable();
        return temp;
    }

    internal IQueryable<Employee>? GetSpecificEmployees(SearchCriteria criteria, string keyword)
    {
        return null;
        switch (criteria)
        {
            case SearchCriteria.FirstName:
                break;
            case SearchCriteria.LastName:
                break;
            case SearchCriteria.HireDate:
                break;
            case SearchCriteria.Age:
                break;
            case SearchCriteria.Title:
                break;
            case SearchCriteria.Salary:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(criteria));
        }
    }
}
