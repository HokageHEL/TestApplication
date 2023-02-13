using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestApplication.ViewModels
{
    internal class DelegateCommand : ICommand
    {
        private Func<Task> value;

        public DelegateCommand(Func<Task> value)
        {
            this.value = value;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
