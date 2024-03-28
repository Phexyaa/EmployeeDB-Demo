﻿using System.Net.Http;
using System.Text.Json;
using System.Windows;
using DesktopApp.Mock;
using DesktopApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Shared.Enums;
using Shared.Global;
using Shared.Utility;

namespace DesktopApp;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider Services { get; }
    public new static App Current = (App)Application.Current;
    private static HostApplicationBuilder builder = Host.CreateApplicationBuilder();
    private static IConfiguration _config => new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

    public App()
    {
        Services = ConfigureServices();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IApiService, MockApi>();
        services.AddSingleton<HttpClient>();
        services.Configure<Settings>(_config.GetSection("Defaults"));
        services.AddSingleton(_config);
        services.AddTransient<IEmployeeFactory, MockEmployeeFactory>();
        services.AddTransient<Defaults>();

        return services.BuildServiceProvider();
    }
}

