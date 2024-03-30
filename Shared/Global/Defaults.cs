using CommunityToolkit.Mvvm.ComponentModel;
using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shared.Global;
public class Defaults : ObservableObject
{
    private Dictionary<SearchCriteria, string> _searchCriteriaToString = new();

    [Required]
    public Dictionary<SearchCriteria, string> SearchCriteriaToString
    {
        get => _searchCriteriaToString;
        set => SetProperty(ref _searchCriteriaToString, value);
    }
    private List<string> _employeeTitles = new();

    [Required]
    public List<string> EmployeeTitles
    {
        get => _employeeTitles;
        set => SetProperty(ref _employeeTitles, value);
    }
}
