using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using ProveedoresApp.Services;
using ProveedoresApp.ViewModels;
using ProveedoresApp.Views;

namespace ProveedoresApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Register services and viewmodels
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<ProveedoresViewModel>();
        builder.Services.AddSingleton<MainPage>();

        return builder.Build();
    }
}