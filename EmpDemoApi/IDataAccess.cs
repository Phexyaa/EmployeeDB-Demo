namespace EmpDemoApi;

public interface IDataAccess
{
    IQueryable<Person> GetPeople();
}