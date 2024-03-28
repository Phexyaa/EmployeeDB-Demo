using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Configuration;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopApp.Services;
public class Settings : ObservableObject
{
    private Dictionary<SearchCriteria, string>? _searchCriteriaToString;

    [Required]
    public Dictionary<SearchCriteria, string>? SearchCriteriaToString
    {
        get => _searchCriteriaToString;
        set => SetProperty(ref _searchCriteriaToString, value);
    }
    private List<string>? _employeeTitles;

    [Required]
    public List<string>? EmployeeTitles
    {
        get => _employeeTitles;
        set => SetProperty(ref _employeeTitles, value);
    }
}
