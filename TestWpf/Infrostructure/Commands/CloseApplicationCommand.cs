#region Using derectives

using System.Windows;
using TestWpf.Infrostructure.Command.Base;

#endregion

namespace TestWpf.Infrostructure.Commands
{
    internal class CloseApplicationCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}