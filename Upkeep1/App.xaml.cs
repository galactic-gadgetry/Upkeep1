using System.Configuration;
using System.Data;
using System.Windows;
using Upkeep1.ViewModels;
using Upkeep1.Views;

namespace Upkeep1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            MainViewModel mainViewModel = new();
            MainWindow = new MainView()
            {
                DataContext = mainViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
