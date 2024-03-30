using Shared.Global;
using Shared.Models;
using System.Windows;
using System.Windows.Input;

namespace DesktopApp.Dialogs;
internal interface IEmployeeDetailsViewModel
{
    ICommand CancelCommand { get; set; }
    Defaults Defaults { get; }
    Employee Employee { get; set; }
    string Error { get; set; }
    Visibility ErrorVisibility { get; set; }
    ICommand ExitErrorCommand { get; set; }
    ICommand SaveCommand { get; set; }
    ICommand GenerateEmployeeIdCommand { get; set; }

    void Dispose();
}