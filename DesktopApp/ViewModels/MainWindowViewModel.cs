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
using Microsoft.Extensions.FileProviders;
using Shared.Interfaces;

namespace DesktopApp
{
    class MainWindowViewModel : ObservableObject
    {
        private readonly IApiService? _apiService;
        private readonly Timer _connectionTestTimer;
        private readonly Defaults? _defaults;
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

        private List<Employee> _employees = new();
        public List<Employee> Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
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

            _connectionTestTimer = new Timer(UpdateConnectionStatusIcon, null, 0, 10000);

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
                        Employees = await _apiService!.GetEmployeesByHireDate(hireDate.ToString("MM-dd-yyyy"), false, false, true);
                        break;
                    case SearchCriteria.Age:
                        int.TryParse(keyword, out int age);
                        Employees = await _apiService!.GetEmployeesByAge(age, false, false, true);
                        break;
                    case SearchCriteria.Title:
                        Employees = await _apiService!.GetEmployeesByTitle(keyword);
                        break;
                    case SearchCriteria.Salary:
                        decimal.TryParse(keyword, out decimal salary);
                        Employees = await _apiService!.GetEmployeesBySalary(salary, false, false, true);
                        break;
                    case SearchCriteria.IsActive:
                        bool.TryParse(keyword, out bool active);
                        if (active)
                            Employees = await _apiService!.GetAllActiveEmployees();
                        else
                            Employees = await _apiService!.GetAllInactiveEmployees();
                        break;
                    case SearchCriteria.EmployeeId:
                        Guid.TryParse(keyword, out Guid id);
                        Employees = await _apiService!.GetEmployeeByEmployeeId(id   );
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(SelectedSearchCriteria));
                }
            }
            else
                Employees = await _apiService!.GetAllEmployees();
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
