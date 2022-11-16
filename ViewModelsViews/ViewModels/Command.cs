using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModelsViews.ViewModels
{
    public class Command : ICommand
    {

        public event EventHandler CanExecuteChanged;
        private IErrorHandler errorHandler;

        private Action executeMethod;
        private Func<bool> canExecute;

        public Command(Action executeMethod, Func<bool> canExecute = null, IErrorHandler errorHundler = null)
        {
            this.executeMethod = executeMethod;
            this.canExecute = canExecute;
            this.errorHandler = errorHundler;
        }

        public bool CanExecute(object _)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object _)
        {
            if (CanExecute(null))
            {
                try
                {
                    executeMethod.Invoke();

                }
                catch (Exception e)
                {
                    if (errorHandler != null)
                    {
                        errorHandler.HandleError(e);
                    }
                    else
                    {
                        throw;
                    }
                }
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
        private IErrorHandler errorHandler;

        public Command(Action<T> executeMethod, Func<T, bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            this.executeMethod = executeMethod;
            this.canExecute = canExecute;
            this.errorHandler = errorHandler;
        }

        public bool CanExecute(object param)
        {
            return canExecute == null ? true : canExecute((T)param);
        }

        public void Execute(object param)
        {
            if (CanExecute(null))
            {
                try
                {
                    executeMethod.Invoke((T)param);
                }
                catch (Exception e)
                {
                    if (errorHandler != null)
                    {
                        errorHandler.HandleError(e);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
