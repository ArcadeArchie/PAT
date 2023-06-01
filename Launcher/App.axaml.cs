using System;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
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
        services.AddTransient<SplashScreenViewModel>();
        services.AddTransient<MainWindowViewModel>();
        return services.BuildServiceProvider();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }



    public override async void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);

            var splash = new SplashScreen()
            {
                DataContext = Current.Services.GetRequiredService<SplashScreenViewModel>(),
            };
            desktop.MainWindow = splash;
            splash.Show();
            await Task.Delay(2000);
            desktop.MainWindow = new MainWindow
            {
                DataContext = Current.Services.GetRequiredService<MainWindowViewModel>(),
            };
            desktop.MainWindow.Show();
            splash.Close();
        }

        base.OnFrameworkInitializationCompleted();
    }
}