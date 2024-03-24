using CommunityToolkit.Mvvm.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace EmpDemoApi;

public class Person : ObservableObject
{
    private string? _firstName;
    public string? FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }
    private int _age;
    public int Age
    {
        get => _age;
        set => SetProperty(ref _age, value);
    }
    private string? _lastName;
    public string? LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }
    public int Id { get; set; }
}
