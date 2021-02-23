#region Using derectives

using System.Windows;
using System.Windows.Input;
using TestWpf.Infrostructure.Commands;

#endregion

namespace TestWpf.ViewModels.Base
{
    internal sealed class MainWindowViewModel : ViewModel
    {
        private string _Title = "Анимэ";

        public MainWindowViewModel() => CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecute, CanCloseAppCommandExecute);

        /// <summary>
        ///     Заголовок окна
        /// </summary>
        public string Title
        {
            get => _Title;

            set => Set(ref _Title, value);
        }

        private ICommand CloseAppCommand { get; }

        private static bool CanCloseAppCommandExecute(object p) => true;

        private void OnCloseAppCommandExecute(object p)
        {
            Application.Current.Shutdown();
        }
    }
}