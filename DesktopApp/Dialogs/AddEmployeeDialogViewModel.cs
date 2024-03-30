using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopApp.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xaml.Behaviors;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopApp.Dialogs;
internal class AddEmployeeDialogViewModel : ObservableObject, IDisposable
{
    private readonly IApiService _apiService;

    private Employee _newEmployee = new();
    public Employee NewEmployee
    {
        get => _newEmployee; set => SetProperty(ref _newEmployee, value);
    }
    private bool _showSaveError = false;
    public bool ShowSaveError
    {
        get => _showSaveError; set => SetProperty(ref _showSaveError, value);
    }
    private bool _canSave = true;
    public bool CanSave
    {
        get => _canSave; set => SetProperty(ref _canSave, value);
    }
    private string? _saveError;
    public string? SaveError
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

    public EventHandler CancelEvent;
    public EventHandler<bool> CloseEvent;


    public ICommand SaveCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public ICommand ExitErrorCommand { get; set; }

    public AddEmployeeDialogViewModel()
    {
        SaveCommand = new AsyncRelayCommand(InsertEmployee);
        SaveCommand.CanExecute(ValidateEmployee());
        ExitErrorCommand = new RelayCommand(() => ErrorVisibility = Visibility.Hidden);
        CancelEvent?.Invoke(this, new EventArgs());


        NewEmployee.HireDate = DateTime.Now;
        _apiService = App.Current.Services.GetRequiredService<IApiService>();

        if (_apiService == null)
            throw new NullReferenceException(nameof(_apiService));

    }

    private async Task InsertEmployee()
    {
        if (ValidateEmployee())
        {
            ErrorVisibility = Visibility.Hidden;
            await _apiService.InsertEmployee(NewEmployee);
            CloseEvent?.Invoke(this, true);
        }
        else
        {
            SaveError = "Invalid employee details were entered; Please try again.";
            ErrorVisibility = Visibility.Visible;
        }
    }

    private bool ValidateEmployee()
    {
        var nameValidator = new NameValidator();
        var ageValidator = new AgeValidator();
        var titleValidator = new EmployeeTitleValidator();
        var employeeIDValidator = new EmployeeIdValidator();
        var dateValidator = new DateValidator();
        var salaryValidator = new SalaryValidator();

        return NewEmployee.FirstName != null &&
            NewEmployee.LastName != null &&
            nameValidator.Validate(NewEmployee.FirstName, new CultureInfo("en")).IsValid
            && nameValidator.Validate(NewEmployee.LastName, new CultureInfo("en")).IsValid
            && ageValidator.Validate(NewEmployee.Age, new CultureInfo("en")).IsValid
            && employeeIDValidator.Validate(NewEmployee.EmployeeId, new CultureInfo("en")).IsValid
            && dateValidator.Validate(NewEmployee.HireDate, new CultureInfo("en")).IsValid
            && salaryValidator.Validate(NewEmployee.Salary, new CultureInfo("en")).IsValid
            && titleValidator.Validate(NewEmployee.Title!, new CultureInfo("en")).IsValid;
    }

    public void Dispose()
    {
        NewEmployee = new();
        CloseEvent?.Invoke(this, false);
    }
}
