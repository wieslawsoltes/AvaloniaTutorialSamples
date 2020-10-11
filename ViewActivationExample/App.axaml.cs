using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ViewActivationExample.ViewModels;

namespace ViewActivationExample
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new View()
                {
                    DataContext = new ViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
