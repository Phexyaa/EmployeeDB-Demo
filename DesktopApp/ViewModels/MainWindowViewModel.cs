using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace DesktopApp
{
    class MainWindowViewModel : ObservableObject
    {
        private readonly IApiService? _apiService;
        private readonly Timer _connectionTestTimer;

        public string Title { get; set; } = "Employee Lookup Demo";
        public string CriteriaLabelText { get; set; } = "Search by:";

        private ImageSource connectionOkIcon = new BitmapImage(new Uri(@"/Assets/database-check.png", UriKind.Relative));
        private ImageSource connectionFailedIcon = new BitmapImage(new Uri(@"/Assets/database-slash.png", UriKind.Relative));
        private ImageSource _connectionStatusIcon;
        public ImageSource ConnectionStatusIcon
        {
            get => _connectionStatusIcon;
            set => SetProperty(ref _connectionStatusIcon, value);
        }

        private Brush connectionStatusOkBackground = Brushes.Green;
        private Brush connectionStatusFailBackground = Brushes.Red;
        private Brush _connectionStatusBackground;
        public Brush ConnectionStatusBackground
        {
            get => _connectionStatusBackground;
            set => SetProperty(ref _connectionStatusBackground, value);
        }

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
            if (_apiService == null)
                throw new NullReferenceException(nameof(_apiService));

            SearchCommand = new RelayCommand<string>(Search);

            _connectionTestTimer = new Timer(UpdateConnectionStatusIcon, null, 0, 10000);

        }

        public void Search(string? keyword)
        {
            if (!string.IsNullOrWhiteSpace(keyword))
                Employees = _apiService!.GetEmployees()
                    .Where(e =>
                        (e.FirstName != null && e.FirstName.Contains(keyword))
                        || (e.LastName != null && e.LastName.Contains(keyword))).ToList();
            else
                Employees = _apiService!.GetEmployees();
        }

        private bool CheckConnection() => _apiService!.GetConnectionStatus();

        private void UpdateConnectionStatusIcon(object? state)
        {
            if (CheckConnection())
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
