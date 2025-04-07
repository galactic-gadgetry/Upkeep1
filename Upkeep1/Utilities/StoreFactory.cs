using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upkeep1.Stores;

namespace Upkeep1.Utilities
{
    public static class StoreFactory
    {

        public static NavigationStore CreateNavigationStore()
        {
            return new NavigationStore();
        }
    }
}
