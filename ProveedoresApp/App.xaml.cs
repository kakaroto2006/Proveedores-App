using Microsoft.Maui.Controls;

namespace ProveedoresApp;

public partial class App : Application
{
    public App(IServiceProvider services)
    {
        InitializeComponent();
        MainPage = services.GetService<MainPage>() ?? new MainPage();
    }
}