using CommunityToolkit.Mvvm.Input;
using DesktopApp.API;
using Shared.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Input;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Global;
using System.Windows.Navigation;
using System.Text.Json;
using System.CodeDom;
using DesktopApp.Validators;

namespace DesktopApp.Dialogs.ViewModels
{
    class EditEmployeeViewModel : ObservableObject, IEmployeeDetailsViewModel, IDisposable
    {
        private readonly IApiService _apiService;
        private readonly Defaults _defaults;
        private YesNoDialogView? _userConfirmationDialog;

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

        public EditEmployeeViewModel(string employeeAsJson)
        {
            ExitErrorCommand = new RelayCommand(() => ErrorVisibility = Visibility.Hidden);
            SaveCommand = new AsyncRelayCommand(UpdateEmployee);
            SaveCommand.CanExecute(EmployeeModelValidator.Validate(Employee));
            CancelCommand = new RelayCommand(() => CloseEvent?.Invoke(this, false));
            GenerateEmployeeIdCommand = new RelayCommand(RefreshEmployeeId);

            _apiService = App.Current.Services.GetRequiredService<IApiService>();
            _defaults = App.Current.Services.GetRequiredService<IOptionsMonitor<Defaults>>().CurrentValue;

            if (_apiService == null)
                throw new NullReferenceException(nameof(_apiService));
            if (_defaults == null)
                throw new NullReferenceException(nameof(_defaults));

            Employee = JsonSerializer.Deserialize<Employee>(employeeAsJson)
                ?? throw new ArgumentException("Could not parse employee data provided.", nameof(employeeAsJson));
        }

        private void RefreshEmployeeId()
        {
            var confirmationDataContext = new ConfirmationDialogViewModel();
            confirmationDataContext.ConfirmationPrompt = "Please confirm that you want to over-write the existing employee ID.";
            confirmationDataContext.UserAccepted += OverWriteEmployeeId;
            confirmationDataContext.UserRefused += CloseConfirmationDialog;

            _userConfirmationDialog = new YesNoDialogView();
            _userConfirmationDialog.DataContext = confirmationDataContext;

            _userConfirmationDialog.ShowDialog();
        }

        private void CloseConfirmationDialog(object? sender, EventArgs e) => _userConfirmationDialog?.Close();

        private void OverWriteEmployeeId(object? sender, EventArgs args)
        {
            Employee.EmployeeId = Guid.NewGuid().ToString();
            _userConfirmationDialog?.Close();
        }

        private async Task UpdateEmployee()
        {
            if (EmployeeModelValidator.Validate(Employee))
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
