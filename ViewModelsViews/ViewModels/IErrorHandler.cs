using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModelsViews.ViewModels
{
    public interface IErrorHundler
    {
        static IErrorHundler Empty => new EmptyErrorHandler();
        void HandleError(Exception ex);
    }

    internal class EmptyErrorHandler : IErrorHundler
    {
        public void HandleError(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
