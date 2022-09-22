using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModelsViews.ViewModels.Commands
{
    public class Command : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private Action executeMethod;
        private Func<bool> canExecute;

        public Command(Action executeMethod, Func<bool> canExecute = null)
        {
            this.executeMethod = executeMethod;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object parameter)
        {
            
        }
    }
}
