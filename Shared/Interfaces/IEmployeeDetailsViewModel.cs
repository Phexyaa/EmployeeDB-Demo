using Shared.Global;
using Shared.Models;
using System.Windows;
using System.Windows.Input;

namespace Shared.Interfaces;
public interface IEmployeeDetailsViewModel
{
     public ICommand CancelCommand { get; set; }
    public Defaults Defaults { get; }
    public Employee Employee { get; set; }
    public string Error { get; set; }
    public ICommand ExitErrorCommand { get; set; }
    public ICommand SaveCommand { get; set; }
    public ICommand GenerateEmployeeIdCommand { get; set; }

    void Dispose();
}