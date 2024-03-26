﻿using System.Net.Http;
using System.Windows;
using DesktopApp.Mock;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Utility;

namespace DesktopApp;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider Services { get; }
    public new static App Current = (App)Application.Current;

    private HostApplicationBuilder builder = Host.CreateApplicationBuilder();
    public App()
    {
        Services = ConfigureServices();

        
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IApiService, MockApi>();
        services.AddSingleton<HttpClient>();
        services.AddTransient<IEmployeeFactory, MockEmployeeFactory>();

        return services.BuildServiceProvider();
    }
}

