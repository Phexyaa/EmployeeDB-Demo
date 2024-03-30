using CommunityToolkit.Mvvm.Input;
using DesktopApp.API;
using Shared.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Input;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using DesktopApp.Models;
using Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Global;

namespace DesktopApp.Dialogs
{
    class EditEmployeeViewModel : ObservableObject, IEmployeeDetailsViewModel, IDisposable
    {
        private readonly IApiService _apiService;
        private readonly Defaults _defaults;

        public Defaults Defaults { get { return _defaults; } }

        private Employee _employee = new();
        public Employee Employee
        {
            get => _employee; set => SetProperty(ref _employee, value);
        }
        private string _saveError = "";
        public string Error
        {
            get => _saveError;
            set => SetProperty(ref _saveError, value);

        }
        private Visibility _errorVisibility = Visibility.Collapsed;
        public Visibility ErrorVisibility
        {
            get => _errorVisibility;
            set => SetProperty(ref _errorVisibility, value);

        }

        public EventHandler? CancelEvent;
        public EventHandler<bool>? CloseEvent;
        public ICommand CancelCommand { get; set; }
        public ICommand ExitErrorCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public EditEmployeeViewModel(Employee employee)
        {
            ExitErrorCommand = new RelayCommand(() => ErrorVisibility = Visibility.Hidden);
            SaveCommand = new AsyncRelayCommand(UpdateEmployee);
            SaveCommand.CanExecute(EmployeeValidator.Validate(Employee));
            CancelCommand = new RelayCommand(() => CloseEvent?.Invoke(this, false));

            _apiService = App.Current.Services.GetRequiredService<IApiService>();
            _defaults = App.Current.Services.GetRequiredService<IOptionsMonitor<Defaults>>().CurrentValue;

            if (_apiService == null)
                throw new NullReferenceException(nameof(_apiService));
            if (_defaults == null)
                throw new NullReferenceException(nameof(_defaults));

            Employee = employee;
        }
        private async Task UpdateEmployee()
        {
            if (EmployeeValidator.Validate(Employee))
            {
                ErrorVisibility = Visibility.Hidden;
                await _apiService.UpdateEmployee(Employee);
                CloseEvent?.Invoke(this, true);
            }
            else
            {
                Error = "Invalid employee details were entered; Please try again.";
                ErrorVisibility = Visibility.Visible;
            }
        }
        public void Dispose()
        {
            Error = "";
            Employee = new();
            CloseEvent?.Invoke(this, false);
        }
    }
}
