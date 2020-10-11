using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using ReactiveUI;

namespace ViewActivationExample.ViewModels
{
    public class ViewModel : ReactiveObject, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; }

        public ReactiveCommand<int, Unit> ExampleCommand { get; }

        public ViewModel()
        {
            Activator = new ViewModelActivator();

            ExampleCommand = ReactiveCommand.Create<int>(integer => Debug.WriteLine(integer));

            this.WhenActivated((CompositeDisposable disposables) =>
            {
                /* handle activation */
                Disposable
                    .Create(() => { /* handle deactivation */ })
                    .DisposeWith(disposables);
            });
        }
    }
}
