using Inventory_Management_System_WPF.Commands;
using Inventory_Management_System_WPF.Models;
using Inventory_Management_System_WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inventory_Management_System_WPF.ViewModels
{
    public class AddProductViewModel: BaseViewModel
    {
        #region Properites
        public ICommand AddProductCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        #endregion

        public AddProductViewModel(Inventory inventory, NavigationStore navigationStore, Func<MainMenuViewModel> createMainMenuViewModel)
        {
            AddProductCommand = new AddProductCommand();
            CancelCommand = new NavigateCommand(navigationStore, createMainMenuViewModel);
        }

    }
}
