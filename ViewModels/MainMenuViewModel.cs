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
    public class MainMenuViewModel: BaseViewModel
    {
        #region Properites
        public ICommand AddProductCommand { get; set; }
        public ICommand RemoveProductCommand { get; set; }
        public ICommand BrowseProductsCommand { get; set; }
        public ICommand QuitCommand { get; set; }
        #endregion

        #region Constructor
        public MainMenuViewModel(Inventory inventory, NavigationStore navigationStore, Func<AddProductViewModel> createAddProductVM, Func<RemoveProductViewModel> createRemoveProductVM, Func<BrowseProductsViewModel> createBrowseProductsVM)
        {
            AddProductCommand = new NavigateCommand(navigationStore, createAddProductVM);
            RemoveProductCommand = new NavigateCommand(navigationStore, createRemoveProductVM);
            BrowseProductsCommand = new NavigateCommand(navigationStore, createBrowseProductsVM); 
            QuitCommand = new QuitCommand();
        }
        #endregion

    }
}
