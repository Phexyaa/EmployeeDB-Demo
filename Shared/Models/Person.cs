using CommunityToolkit.Mvvm.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Shared.Models;

public class Person : ObservableObject
{
    public Guid Id { get; set; }
    private string? _firstName;
    public string? FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }
    private string? _lastName;
    public string? LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }
    private int _age;
    public int Age
    {
        get => _age;
        set => SetProperty(ref _age, value);
    }

    public Person() => Id = Guid.NewGuid();
}
