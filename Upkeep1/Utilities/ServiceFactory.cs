using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upkeep1.Services;
using Upkeep1.Stores;
using Upkeep1.ViewModels;

namespace Upkeep1.Utilities
{
    public static class ServiceFactory
    {

        public static INavigate CreateNavigationService(string type,
            NavigationStore navigationStore)
        {
            switch (type.ToLower())
            {
                case "daily timesheet":
                    return new LayoutNavigationService<DailyTimesheetViewModel>(
                        navigationStore,
                        () => new DailyTimesheetViewModel());
                case "layout":
                    return new NavigationService<LayoutViewModel>(
                        navigationStore,
                        () => new LayoutViewModel(navigationStore));
                case "navigation bar":
                    return new NavBarNavigationService<NavigationBarViewModel>(
                        navigationStore,
                        () => new NavigationBarViewModel(navigationStore));
                case "projects":
                    return new LayoutNavigationService<ProjectsViewModel>(
                        navigationStore,
                        () => new ProjectsViewModel());
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
