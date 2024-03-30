using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopApp.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Global;
using Shared.Interfaces;
using Shared.Models;
using System.Windows;
using System.Windows.Input;

namespace DesktopApp.Dialogs.ViewModels
{
    class AddEmployeeViewModel : ObservableObject, IEmployeeDetailsViewModel, IDisposable
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
        public ICommand GenerateEmployeeIdCommand { get; set; }
        public AddEmployeeViewModel()
        {
            ExitErrorCommand = new RelayCommand(() => ErrorVisibility = Visibility.Hidden);
            SaveCommand = new AsyncRelayCommand(InsertEmployee);
            SaveCommand.CanExecute(EmployeeModelValidator.Validate(Employee));
            CancelCommand = new RelayCommand(() => CloseEvent?.Invoke(this, false));
            GenerateEmployeeIdCommand = new RelayCommand(RefreshEmployeeId);

            _apiService = App.Current.Services.GetRequiredService<IApiService>();
            _defaults = App.Current.Services.GetRequiredService<IOptionsMonitor<Defaults>>().CurrentValue;

            if (_apiService == null)
                throw new NullReferenceException(nameof(_apiService));
            if (_defaults == null)
                throw new NullReferenceException(nameof(_defaults));

            Employee.HireDate = DateTime.Now;
            Employee.Title = _defaults.EmployeeTitles.First();
        }
        private void RefreshEmployeeId()
        {
            Employee.EmployeeId = Guid.NewGuid().ToString();
        }
        private async Task InsertEmployee()
        {
            if (EmployeeModelValidator.Validate(Employee))
            {
                ErrorVisibility = Visibility.Hidden;
                await _apiService.InsertEmployee(Employee);
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
