﻿using Shared.Models;
using Shared.Global;
using Microsoft.Extensions.Options;

namespace Shared.Utility;

public class MockEmployeeFactory : IEmployeeFactory
{
    private readonly Defaults _defaults;
    private readonly List<string> FirstNames = new List<string>()
    {
        "Valeria",
        "Laylah",
        "Jordin",
        "Juan",
        "Anthony",
        "Gerald",
        "Mariah",
        "Judith",
        "Rafael",
        "Fernando",
        "Lorenzo",
        "Raegan",
        "Aiyana",
        "Donald",
        "Kaylee",
        "Laura",
        "Easton",
        "Bronson",
        "Nick",
        "Freddy",
        "Oswaldo",
        "Spencer",
        "Danica",
        "Hana",
        "Shyanne",
        "Madeline",
        "Chase",
        "Lyric",
        "Quinten",
        "Reese",
        "Josephine",
        "Ana",
        "Sydnee",
        "Kamora",
        "Amirah",
        "Rebecca",
        "Eric",
        "Colby",
        "Kendra",
        "Emery",
        "Jaylin",
        "Hayley",
        "Thomas",
        "Danika",
        "Juliette",
        "Jessie",
        "Owen",
        "Kobe",
        "Damaris",
        "Anahi",
        "London",
        "Tatiana",
        "Ellie",
        "Paityn",
        "Edith",
        "Melina",
        "Sharon",
        "Brittany",
        "Camren",
        "Ryker",
        "Kelly",
        "Aurora",
        "Kale",
        "Reed",
        "Marquis",
        "Deshawn",
        "Axel",
        "Angelica",
        "Quinn",
    };
    private readonly List<string> LastNames = new List<string>()
    {
        "Bauer",
        "Mullen",
        "Lloyd",
        "Lucas",
        "Hebert",
        "Cooper",
        "Bentley",
        "Jimenez",
        "Reese",
        "Berry",
        "Warren",
        "Everett",
        "Gardner",
        "Walker",
        "Schwartz",
        "Spears",
        "Holt",
        "Sheppard",
        "Frye",
        "Meyer",
        "Davis",
        "Christian",
        "Marsh",
        "Crosby",
        "Kelley",
        "Pittman",
        "Brock",
        "Khan",
        "Pugh",
        "Waller",
        "Pham",
        "Andrews",
        "Potter",
        "Ferrell",
        "Allison",
        "Welch",
        "Hardy",
        "Lee",
        "Reed",
        "Kirby",
        "Diaz",
        "Wolfe",
        "Wolf",
        "Potts",
        "Salinas",
        "Sherman",
        "Booth",
        "Carlson",
        "Ayala",
        "Mcguire",
        "Fischer",
        "Williams",
        "Humphrey",
        "Joseph",
        "Hess",
        "Daniels",
        "Mathews",
        "Duke",
        "Jensen",
        "Avila",
        "Spencer",
        "Vang",
        "Espinoza",
        "Medina",
        "Gonzales",
        "Fletcher",
        "Santos",
        "Rivers",
        "Keller",
    };
    private static int RandomAge => new Random().Next(1, 101);
    private static int RandomDay => new Random().Next(1, 29);
    private static int RandomMonth => new Random().Next(1, 13);
    private static int RandomYear => new Random().Next(1900, 2025);
    private static int RandomSalary => new Random().Next(60000, 125001);
    private static DateTime RandomDate => new DateTime(RandomYear, RandomMonth, RandomDay);

    public MockEmployeeFactory(IOptions<Defaults> defaults)
    {
        _defaults = defaults.Value;
        if(_defaults is null)
            throw new NullReferenceException(nameof(_defaults));
    }

    public Employee CreateGenericEmployee()
    {
        return CreateEmployee();
    }
    public Employee CreateEmployee(string firstName = "", string lastName = "", int salary = 0, string title = "",
                                 DateTime hireDate = new DateTime(), int age = 0)
    {
        return new Employee()
        {
            Age = RandomAge,
            Salary = RandomSalary,
            FirstName = FirstNames[new Random().Next(0, FirstNames.Count)],
            LastName = LastNames[new Random().Next(0, LastNames.Count)],
            HireDate = RandomDate,
            Title = _defaults.EmployeeTitles![new Random().Next(0, _defaults.EmployeeTitles.Count)],
            EmployeeId = Guid.NewGuid().ToString(),
        };
    }
}
