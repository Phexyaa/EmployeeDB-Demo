﻿using Shared.Models;

namespace Shared.Interfaces;
public interface IDataService
{
    public Task<List<Employee>> GetEmployeeByEmployeeId(string employeeId);
    public Task<List<Employee>> GetEmployeeByDatabaseId(int databaseId);
    public  Task<List<Employee>> GetAllEmployees();
    public  Task<List<Employee>> GetAllActiveEmployees();
    public  Task<List<Employee>> GetAllInactiveEmployees();
    public  Task<List<Employee>> GetEmployeesByAge(int age, bool greaterThan, bool lessThan, bool equalTo);
    public  Task<List<Employee>> GetEmployeesByHireDate(string hireDate, bool greaterThan, bool lessThan, bool equalTo);
    public Task<List<Employee>> GetEmployeesByFirstName(string firstName);
    public Task<List<Employee>> GetEmployeesByLastName(string lastName);
    public  Task<List<Employee>> GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo);
    public  Task<List<Employee>> GetEmployeesByTitle(string title);
    public Task<int> DeleteEmployeeRecord(int databaseId);
    public Task<int> InsertEmployee(Employee employee);
    public Task<int> UpdateEmployee(Employee employee);

}
