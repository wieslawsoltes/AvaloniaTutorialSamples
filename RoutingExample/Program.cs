using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RoutingExample.ViewModels;
using RoutingExample.Views;
using Splat;

namespace RoutingExample
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
        {
            // Router uses Splat.Locator to resolve views for
            // view models, so we need to register our views.
            //
            Locator.CurrentMutable.Register(() => new FirstView(), typeof(IViewFor<FirstViewModel>));

            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .LogToDebug();
        }
    }
}
