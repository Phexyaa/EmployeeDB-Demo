using System.Windows.Input;

namespace Shared.Interfaces;
public interface IConfirmationDialogViewModel
{
    public ICommand AcceptCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public EventHandler? UserAccepted { get; set; }
    public EventHandler? UserRefused { get; set; }
    public string ConfirmationPrompt { get; set; }
}