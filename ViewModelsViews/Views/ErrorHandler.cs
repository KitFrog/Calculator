using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ViewModelsViews.ViewModels;

namespace ViewModelsViews.Views
{
    class ErrorHandler : IErrorHundler
    {
        public void HandleError(Exception ex)
        {
            string text = "";
            if (ex is DivideByZeroException)
            {
                text = "Делитель равен нулю";
            }
            else if (ex is OverflowException)
            {
                text = "Слишком больше число";
            }
            else
            {
                text = ex.Message;
            }
            MessageBox.Show(text, "Error",MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }
}
