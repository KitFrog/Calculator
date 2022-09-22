using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Globalization;

namespace ViewModelsViews.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string Comma => CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        private Calulations model = new Calulations();
        private string display = "543/10";

        public string Display
        {
            get => display;
            set
            {
                display = value;
                OnPropertyChanged("Display");
            }
        }

    }
}
