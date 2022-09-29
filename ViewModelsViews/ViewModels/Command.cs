using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModelsViews.ViewModels
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

        public bool CanExecute(object _)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object _)
        {
            if (CanExecute(null))
            {
                executeMethod.Invoke();
            }
        }

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class Command<T> : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private Action<T> executeMethod;
        private Func<T, bool> canExecute;

        public Command(Action<T> executeMethod, Func<T, bool> canExecute = null)
        {
            this.executeMethod = executeMethod;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object param)
        {
            return canExecute == null ? true : canExecute((T)param);
        }

        public void Execute(object param)
        {
            if (CanExecute(null))
            {
                executeMethod.Invoke((T)param);
            }
        }

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
