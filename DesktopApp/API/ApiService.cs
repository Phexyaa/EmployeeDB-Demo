using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesktopApp.API;
internal class ApiService : IApiService
{
    private readonly ApiOptions? _options;
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    public ApiService()
    {
        _options = App.Current.Services.GetRequiredService<IOptionsMonitor<ApiOptions>>().CurrentValue;
        if (_options is null || _options.AllowedHost is null)
            throw new NullReferenceException(nameof(_options));

        _client = App.Current.Services.GetRequiredService<HttpClient>();
        if (_client is null)
            throw new NullReferenceException(nameof(_client));
        else
            _client.BaseAddress = new Uri(_options.AllowedHost);

        _jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };
    }
    public async Task<bool> ConnectionTest()
    {
        var response = await _client.GetAsync("ConnectionTest");
        if (response.IsSuccessStatusCode)
            return true;
        else
            return false;
    }

    public async Task<List<Employee>> GetEmployeeByEmployeeId(Guid employeeId)
    {
        var response = await _client.GetAsync($"GetEmployeeByEmployeeId/{employeeId}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }

    public async Task<List<Employee>> GetEmployeeByDatabaseId(int databaseId)
    {
        var response = await _client.GetAsync($"GetEmployeeByDatabaseId/{databaseId}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }
    public async Task<List<Employee>> GetAllEmployees()
    {
        var response = await _client.GetAsync("GetAllEmployees");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }

    public async Task<List<Employee?>> GetAllActiveEmployees()
    {
        var response = await _client.GetAsync("GetAllActiveEmployees");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }

    public async Task<List<Employee?>> GetAllInactiveEmployees()
    {
        var response = await _client.GetAsync("GetAllInactiveEmployees");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }

    public async Task<List<Employee?>> GetEmployeesByAge(int age, bool greaterThan, bool lessThan, bool equalTo)
    {
        var response = await _client.GetAsync($"GetEmployeesByAge/{age}/{greaterThan}/{lessThan}/{equalTo}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }

    public async Task<List<Employee?>> GetEmployeesByHireDate(string hireDate, bool greaterThan, bool lessThan, bool equalTo)
    {
        var response = await _client.GetAsync($"GetEmployeesByHireDate/{hireDate}/{greaterThan}/{lessThan}/{equalTo}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }

    public async Task<List<Employee?>> GetEmployeesByFirstName(string firstName)
    {
        var response = await _client.GetAsync($"GetEmployeesByFirstName/{firstName}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }
    public async Task<List<Employee?>> GetEmployeesByLastName(string lastName)
    {
        var response = await _client.GetAsync($"GetEmployeesByLastName/{lastName}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }

    public async Task<List<Employee?>> GetEmployeesBySalary(decimal salary, bool greaterThan, bool lessThan, bool equalTo)
    {
        var response = await _client.GetAsync($"GetEmployeesBySalary/{salary}/{greaterThan}/{lessThan}/{equalTo}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }

    public async Task<List<Employee?>> GetEmployeesByTitle(string title)
    {
        var response = await _client.GetAsync($"GetEmployeesByTitle/{title}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Employee>>(json, _jsonSerializerOptions);
            if (result is not null)
                return result;
            else
                return new List<Employee>();
        }
        else
            return new List<Employee>();
    }

    public async Task<int> InsertEmployee(Employee employee)
    {
        var response = await _client.GetAsync("InsertEmployee");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<int>(json, _jsonSerializerOptions);
            return result;
        }
        else
            return 0;
    }

    public async Task<int> UpdateEmployee(Employee employee)
    {
        var response = await _client.GetAsync("UpdateEmployee");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<int>(json, _jsonSerializerOptions);
            return result;
        }
        else
            return 0;
    }
    public async Task<int> DeleteEmployeeRecord(int databaseId)
    {
        var response = await _client.GetAsync("DeleteEmployeeRecord");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<int>(json, _jsonSerializerOptions);
            return result;
        }
        else
            return 0;
    }
}
