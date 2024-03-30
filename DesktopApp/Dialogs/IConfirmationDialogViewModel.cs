using System.Windows.Input;

namespace DesktopApp.Dialogs;
internal interface IConfirmationDialogViewModel
{
    ICommand AcceptCommand { get; set; }
    ICommand CancelCommand { get; set; }
    public EventHandler? UserAccepted { get; set; }
    public EventHandler? UserRefused { get; set; }
    public string ConfirmationPrompt { get; set; }
}