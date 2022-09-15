using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModelsViews.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string display = "Some text";
        public string Display{ get=>display; set {
                display = value;
                OnPropertyChanged("Display");
            }
        }
    }
}
