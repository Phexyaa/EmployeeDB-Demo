using Shared.Models;

namespace API.Data;
public interface IEmployeeFactory
{
    Person CreateEmployee(string firstName, string lastName, int salary, string title, DateTime hireDate, int age = 0);
}