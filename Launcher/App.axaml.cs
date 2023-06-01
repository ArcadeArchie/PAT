using System;
using System.Security.Authentication.ExtendedProtection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using PAT.Launcher.ViewModels;
using PAT.Launcher.Views;

namespace PAT.Launcher;

public partial class App : Application
{
    public new static App Current => (App)Application.Current!;
    public IServiceProvider Services { get; }

    public App()
    {        
        Services = ConfigureServices();
    }

    private IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        return services.BuildServiceProvider();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }



    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}