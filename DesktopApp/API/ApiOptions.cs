using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.API;
internal class ApiOptions : ObservableObject
{
    private string? _allowedHost;
    public string? AllowedHost
    {
        get => _allowedHost; set => SetProperty(ref _allowedHost, value);
    }
}
