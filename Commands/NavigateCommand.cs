using Inventory_Management_System_WPF.Stores;
using Inventory_Management_System_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.Commands
{
    public class NavigateCommand : BaseCommand
    {
        #region Properties
        private NavigationStore _navigationStore;
        private Func<BaseViewModel> _createViewModel;
        #endregion

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }

        public NavigateCommand(NavigationStore navigationStore, Func<BaseViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
    }
}
