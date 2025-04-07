using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upkeep1.Services;
using Upkeep1.Stores;
using Upkeep1.Utilities;

namespace Upkeep1.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        /// <summary>
        /// Used by the view-model to determine the app's navigation
        /// state.
        /// </summary>
        private readonly NavigationStore _navigationStore;



        public ViewModelBase? CurrentContentViewModel =>
            _navigationStore.CurrentLayoutContentViewModel;


        public ViewModelBase? CurrentNavigationBarViewModel =>
            _navigationStore.CurrentNavigationBarViewModel;


        public ViewModelBase? CurrentSideContentViewModel =>
            _navigationStore.CurrentSideContentViewModel;



        public LayoutViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentLayoutContentViewModelChanged +=
                OnCurrentLayoutContentViewModelChanged;
            _navigationStore.CurrentNavigationBarViewModelChanged +=
                OnCurrentNavigationBarViewModelChanged;
            _navigationStore.CurrentSideContentViewModelChanged +=
                OnCurrentSideContentViewModelChanged;
        }



        private void NavigateDefaultView()
        {
            throw new NotImplementedException();
            INavigate projectsNavigationService =
                ServiceFactory.CreateNavigationService(
                    "projects",
                    _navigationStore);

            projectsNavigationService.Navigate();
        }


        private void NavigateDefaultViewConstituents()
        {
            INavigate navBarNavigationService =
                ServiceFactory.CreateNavigationService(
                    "navigation bar",
                    _navigationStore);
            //INavigate sideContentNavigationService =
            //    ServiceFactory.CreateNavigationService(
            //        "null side content",
            //        _navigationStore);

            navBarNavigationService.Navigate();
            //sideContentNavigationService.Navigate();
        }


        private void OnCurrentLayoutContentViewModelChanged()
        {
            if (CurrentContentViewModel is DefaultViewModelBase)
            {
                NavigateDefaultViewConstituents();
            }
            else if (CurrentContentViewModel is null)
            {
                NavigateDefaultView();
            }

            OnPropertyChanged(nameof(CurrentContentViewModel));
        }


        private void OnCurrentNavigationBarViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentNavigationBarViewModel));
        }


        private void OnCurrentSideContentViewModelChanged()
        {
            throw new NotImplementedException();
        }
    }
}
