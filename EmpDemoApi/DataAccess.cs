﻿using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

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
