using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Upkeep1.Commands;
using Upkeep1.Services;
using Upkeep1.Stores;
using Upkeep1.Utilities;

namespace Upkeep1.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        /// <summary>
        /// Used by the view-model to determine the app's navigation
        /// state.
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Used by the view-model to navigate to the Projects view.
        /// </summary>
        private readonly INavigate _projectsNavigationService;

        /// <summary>
        /// Used by the view-model to navigate to the Daily timesheet
        /// view.
        /// </summary>
        private readonly INavigate _timesheetNavigationService;


        /// <summary>
        /// Executed when the Projects button is clicked.
        /// </summary>
        public ICommand ProjectsButtonClickedCommand { get; }

        /// <summary>
        /// Executed when the Timesheet button is clicked.
        /// </summary>
        public ICommand TimesheetButtonClickedCommand { get; }



        public NavigationBarViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _projectsNavigationService =
                ServiceFactory.CreateNavigationService(
                    "projects",
                    _navigationStore);
            _timesheetNavigationService =
                ServiceFactory.CreateNavigationService(
                    "daily timesheet",
                    _navigationStore);

            ProjectsButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnProjectsButtonClicked));
            TimesheetButtonClickedCommand = new RelayCommand(
                new Action<object?>(OnTimesheetButtonClicked));
        }


        /// <summary>
        /// Handles the Projects navigation bar button click event.
        /// </summary>
        /// <param name="obj"></param>
        private void OnProjectsButtonClicked(object? obj)
        {
            _projectsNavigationService.Navigate();
        }

        /// <summary>
        /// Handles the Timesheet navigation bar button click event.
        /// </summary>
        /// <param name="obj"></param>
        private void OnTimesheetButtonClicked(object? obj)
        {
            _timesheetNavigationService.Navigate();
        }
    }
}
