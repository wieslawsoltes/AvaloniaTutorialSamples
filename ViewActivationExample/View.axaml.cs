using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using ViewActivationExample.ViewModels;

namespace ViewActivationExample
{
    public class View : ReactiveWindow<ViewModel>
    {
        // Assume the Button control has the Name="ExampleButton" attribute defined in XAML.
        public Button ExampleButton => this.FindControl<Button>("ExampleButton");

        public View()
        {
            // ViewModel's WhenActivated block will also get called.
            //this.WhenActivated(disposables => { /* Handle view activation etc. */ });

            this.WhenActivated(disposables =>
            {
                // Bind the 'ExampleCommand' to 'ExampleButton' defined above.
                this.BindCommand(ViewModel, x => x.ExampleCommand, x => x.ExampleButton)
                    .DisposeWith(disposables);
            });

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
