using Inventory_Management_System_WPF.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        #region Properties
        private NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        #endregion

        #region Constructor
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.OnViewModelChanged += OnViewModelChanged;
        }
        #endregion

        #region Methods
        private void OnViewModelChanged()
        {
            RaiseOnPropertyChanged(nameof(CurrentViewModel));
        }
        #endregion
    }
}
