using Inventory_Management_System_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.Stores
{
    public class NavigationStore
    {
        public event Action OnViewModelChanged;

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                RaiseOnViewModelChanged();
            }
        }

        protected virtual void RaiseOnViewModelChanged()
        {
            OnViewModelChanged?.Invoke();
        } 
    }
}
