using Shared.Enums;

namespace Shared.Global;
public class Defaults
{
    public List<string> Titles { get; } =
    new List<string>()
    {
        "Executive",
        "Manager",
        "Assistant Manager",
        "Secretary",
        "N/A"
    };

    public Dictionary<SearchCriteria, string> SearchCriteriaToString { get; } = 
        new Dictionary<SearchCriteria, string>()
    {
            {SearchCriteria.FirstName, "First Name" },
            {SearchCriteria.LastName, "Last Name" },
            {SearchCriteria.Salary, "Salary" },
            {SearchCriteria.HireDate, "Hire Date" },
            {SearchCriteria.Age, "Age" },
            {SearchCriteria.Title, "Title" }
    };
}
