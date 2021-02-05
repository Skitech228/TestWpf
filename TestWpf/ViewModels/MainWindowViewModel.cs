using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestWpf.Infrostructure.Commands;

namespace TestWpf.ViewModels.Base
{
    class MainWindowViewModel:ViewModel
    {
        public string _Title="Анимэ";

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => _Title;

            set=>  Set(ref _Title, value);
        }


        public ICommand CloseAppCommand { get; }
        public bool CanCloseAppCommandExecute(object p) => true;
        public void OnCloseAppCommandExecute(object p)
        {
            Application.Current.Shutdown();
        }
        public MainWindowViewModel()
        {
            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecute, CanCloseAppCommandExecute);
        }
    }
}
