using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopApp.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopApp
{
    class MainWindowViewModel : ObservableObject
    {
        private readonly IApiService? _apiService;
        public string Title { get; set; } = "test";
        public Employee Employee { get; set; } = new Employee();

        public ICommand SearchCommand { get; }
        private List<Employee>? _employees;
        public List<Employee>? Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
        }
        public MainWindowViewModel()
        {
            _apiService = App.Current.Services.GetService<IApiService>();
            Employee.FirstName = "George";
            SearchCommand = new RelayCommand<string>(Search);
        }

        public void Search(string keyword)
        {
            if (_apiService != null)
            {
                if (!string.IsNullOrWhiteSpace(keyword))
                    Employees = _apiService.GetEmployees().Where(e => e.FirstName.StartsWith(keyword)).ToList();
                else
                    Employees = _apiService.GetEmployees();
            }
        }

    }
}
