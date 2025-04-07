using System.Configuration;
using System.Data;
using System.Windows;
using Upkeep1.Services;
using Upkeep1.Stores;
using Upkeep1.Utilities;
using Upkeep1.ViewModels;
using Upkeep1.Views;

namespace Upkeep1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Used by the application to determine the app's navigation
        /// state.
        /// </summary>
        private readonly NavigationStore _navigationStore;


        public App()
        {
            _navigationStore =
                StoreFactory.CreateNavigationStore();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            INavigate layoutNavigationService =
                ServiceFactory.CreateNavigationService(
                    "layout",
                    _navigationStore);
            INavigate projectsNavigationService =
                ServiceFactory.CreateNavigationService(
                    "projects",
                    _navigationStore);
            layoutNavigationService.Navigate();
            projectsNavigationService.Navigate();

            MainViewModel mainViewModel = new(_navigationStore);
            MainWindow = new MainView()
            {
                DataContext = mainViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
