using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ViewModelsViews.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Calulations model = new Calulations();
        private string display = "";
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
