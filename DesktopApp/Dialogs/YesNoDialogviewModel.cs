using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApp.Dialogs
{
    class ConfirmationDialogViewModel : ObservableObject, IConfirmationDialogViewModel
    {
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        private string _confirmationPrompt ="";
        /// <summary>
        /// The prompt that is displayed to the user.
        /// </summary>
        public string ConfirmationPrompt
        {
            get => _confirmationPrompt; set => SetProperty(ref _confirmationPrompt, value);
        }

        /// <summary>
        /// Event fires whenever a user chooses to accept the prompt.
        /// </summary>
        public EventHandler? UserAccepted { get; set; }

        /// <summary>
        /// Event fires whenever a user refuses the prompt.
        /// </summary>
        public EventHandler? UserRefused { get; set; }

        public ConfirmationDialogViewModel()
        {
            AcceptCommand = new RelayCommand(HandleUserAccept);
            CancelCommand = new RelayCommand(HandleUserCancel);
        }

        private void HandleUserAccept() => UserAccepted?.Invoke(default, new EventArgs());
        private void HandleUserCancel() => UserRefused?.Invoke(default, new EventArgs());
    }
}
