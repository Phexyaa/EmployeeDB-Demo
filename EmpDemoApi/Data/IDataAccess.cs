using Shared.Models;

namespace API.Data;

public interface IDataAccess
{
    IQueryable<Employee> GetPeople();
}