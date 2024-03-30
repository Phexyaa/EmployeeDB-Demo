using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Shared.Enums;
using Microsoft.Extensions.Options;
using Shared.Global;
using DesktopApp.Dialogs;
using Shared.Interfaces;
using System.Text.Json;

namespace DesktopApp
{
    internal class MainWindowViewModel : ObservableObject
    {
        private readonly IApiService? _apiService;
        private readonly Timer _connectionTestTimer;
        private readonly Defaults? _defaults;
        private EmployeeDetailsView _employeeDialog;
        public Defaults? Settings { get => _defaults; }
        public string Title { get; set; } = "Employee Lookup Demo";
        public string CriteriaLabelText { get; set; } = "Search by:";

        public SearchCriteria _selectedSearchCriteria = SearchCriteria.LastName;
        public SearchCriteria SelectedSearchCriteria
        {
            get => _selectedSearchCriteria;
            set => SetProperty(ref _selectedSearchCriteria, value);
        }

        private ImageSource connectionOkIcon = new BitmapImage(new Uri(@"/Assets/database-check.png", UriKind.Relative));
        private ImageSource connectionFailedIcon = new BitmapImage(new Uri(@"/Assets/database-slash.png", UriKind.Relative));
        private ImageSource? _connectionStatusIcon;
        public ImageSource? ConnectionStatusIcon
        {
            get => _connectionStatusIcon;
            set => SetProperty(ref _connectionStatusIcon, value);
        }

        private Brush connectionStatusOkBackground = Brushes.Green;
        private Brush connectionStatusFailBackground = Brushes.Red;
        private Brush? _connectionStatusBackground;
        public Brush? ConnectionStatusBackground
        {
            get => _connectionStatusBackground;
            set => SetProperty(ref _connectionStatusBackground, value);
        }

        public ICommand SearchCommand { get; }
        public ICommand SearchCriteriaSelectedCommand { get; }
        public ICommand ShowAddEmployeeCommand { get; }
        public ICommand EditEmployeeCommand { get; }

        private List<Employee> _employees = new();
        public List<Employee> Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
        }
        private bool _greaterThanComparison;
        public bool GreaterThanComparison
        {
            get => _greaterThanComparison; set => SetProperty(ref _greaterThanComparison, value);
        }
        private bool _lessThanComparison;
        public bool LessThanComparison
        {
            get => _lessThanComparison; set => SetProperty(ref _lessThanComparison, value);
        }
        private bool _equalToComparison = true;
        public bool EqualToComparison
        {
            get => _equalToComparison; set => SetProperty(ref _equalToComparison, value);
        }
        private bool _isComparison;
        public bool IsComparison
        {
            get => _isComparison; set => SetProperty(ref _isComparison, value);
        }


        public MainWindowViewModel()
        {
            var defaultService = App.Current.Services.GetService<IOptionsMonitor<Defaults>>();
            if (defaultService is not null)
                _defaults = defaultService.CurrentValue;
            if (_defaults is null)
                throw new NullReferenceException(nameof(_defaults));

            _apiService = App.Current.Services.GetService<IApiService>();
            if (_apiService == null)
                throw new NullReferenceException(nameof(_apiService));

            SearchCommand = new AsyncRelayCommand<string>(Search);
            EditEmployeeCommand = new RelayCommand<Employee>(EditEmployee);
            SearchCriteriaSelectedCommand = new RelayCommand<SearchCriteria>(SearchCriteriaSelected);
            ShowAddEmployeeCommand = new RelayCommand(ShowAddEmployeeDialog);

            _connectionTestTimer = new Timer(UpdateConnectionStatusIcon, null, 0, 10000);

        }
        public void ShowAddEmployeeDialog()
        {
            var dialogDataContext = new AddEmployeeViewModel();
            _employeeDialog = new EmployeeDetailsView();
            _employeeDialog.DataContext = dialogDataContext;
            dialogDataContext.CloseEvent += CloseAddEmployeeWindowDialog;

            _employeeDialog.ShowDialog();
        }
        public void EditEmployee(Employee? employee)
        {
            var dialogDataContext = new EditEmployeeViewModel(JsonSerializer.Serialize(employee));
            _employeeDialog = new EmployeeDetailsView();
            _employeeDialog.DataContext = dialogDataContext;
            dialogDataContext.CloseEvent += CloseAddEmployeeWindowDialog;

            _employeeDialog.ShowDialog();
        }
        public void CloseAddEmployeeWindowDialog(object? sender, bool isSuccess)
        {
            //Todo: Implement some sort of success popup or icon.
            try
            {
                _employeeDialog.Close();
            }
            catch (InvalidCastException)
            {
                return;
            }
        }
        public async Task Search(string? keyword)
        {
            var criteria = _defaults!.SearchCriteriaToString;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                switch (SelectedSearchCriteria)
                {
                    case SearchCriteria.FirstName:
                        Employees = await _apiService!.GetEmployeesByFirstName(keyword);
                        break;
                    case SearchCriteria.LastName:
                        Employees = await _apiService!.GetEmployeesByLastName(keyword);
                        break;
                    case SearchCriteria.HireDate:
                        DateTime.TryParse(keyword, out var hireDate);
                        Employees = await _apiService!.GetEmployeesByHireDate(hireDate.ToString("MM-dd-yyyy"), GreaterThanComparison, LessThanComparison, EqualToComparison);
                        break;
                    case SearchCriteria.Age:
                        int.TryParse(keyword, out int age);
                        Employees = await _apiService!.GetEmployeesByAge(age, GreaterThanComparison, LessThanComparison, EqualToComparison);
                        break;
                    case SearchCriteria.Title:
                        Employees = await _apiService!.GetEmployeesByTitle(keyword);
                        break;
                    case SearchCriteria.Salary:
                        decimal.TryParse(keyword, out decimal salary);
                        Employees = await _apiService!.GetEmployeesBySalary(salary, GreaterThanComparison, LessThanComparison, EqualToComparison);
                        break;
                    case SearchCriteria.IsActive:
                        bool.TryParse(keyword, out bool active);
                        if (active)
                            Employees = await _apiService!.GetAllActiveEmployees();
                        else
                            Employees = await _apiService!.GetAllInactiveEmployees();
                        break;
                    case SearchCriteria.EmployeeId:
                        Employees = await _apiService!.GetEmployeeByEmployeeId(keyword);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(SelectedSearchCriteria));
                }
            }
            else
                Employees = await _apiService!.GetAllEmployees();
        }

        public void SearchCriteriaSelected(SearchCriteria selectedCriteria)
        {
            switch (selectedCriteria)
            {
                case SearchCriteria.FirstName:
                    IsComparison = false;
                    break;
                case SearchCriteria.LastName:
                    IsComparison = false;
                    break;
                case SearchCriteria.HireDate:
                    IsComparison = true;
                    break;
                case SearchCriteria.Age:
                    IsComparison = true;
                    break;
                case SearchCriteria.Title:
                    IsComparison = false;
                    break;
                case SearchCriteria.Salary:
                    IsComparison = true;
                    break;
                case SearchCriteria.IsActive:
                    IsComparison = false;
                    break;
                case SearchCriteria.EmployeeId:
                    IsComparison = false;
                    break;
            }
        }

        private async Task<bool> CheckConnection() => await _apiService!.ConnectionTest();

        private async void UpdateConnectionStatusIcon(object? state)
        {
            if (await CheckConnection())
            {
                ConnectionStatusIcon = connectionOkIcon;
                ConnectionStatusBackground = connectionStatusOkBackground;
            }
            else
            {
                ConnectionStatusIcon = connectionFailedIcon;
                ConnectionStatusBackground = connectionStatusFailBackground;
            }
        }

    }
}
