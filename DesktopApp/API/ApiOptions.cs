using CommunityToolkit.Mvvm.ComponentModel;

namespace DesktopApp.API;
internal class ApiOptions : ObservableObject
{
    private string? _allowedHost;
    public string? AllowedHost
    {
        get => _allowedHost; set => SetProperty(ref _allowedHost, value);
    }
}
