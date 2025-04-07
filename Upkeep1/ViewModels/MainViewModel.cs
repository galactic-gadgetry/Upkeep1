using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upkeep1.Stores;

namespace Upkeep1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Used by the view-model to determine the app's navigation
        /// state.
        /// </summary>
        private NavigationStore _navigationStore;


        public ViewModelBase? CurrentMainContentViewModel =>
            _navigationStore.CurrentMainContentViewModel;



        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentMainContentViewModelChanged +=
                OnCurrentMainContentViewModelChanged;
        }



        private void OnCurrentMainContentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentMainContentViewModel));
        }
    }
}
