using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModelsViews
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       private void OnStartup(object sender, StartupEventArgs arg)
        {
            var win = new Views.MainWindow();
            win.Show();
        }
       
    }
}
