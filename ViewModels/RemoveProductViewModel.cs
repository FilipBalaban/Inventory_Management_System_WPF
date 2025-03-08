using Inventory_Management_System_WPF.Commands;
using Inventory_Management_System_WPF.Models;
using Inventory_Management_System_WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Inventory_Management_System_WPF.ViewModels
{
    public class RemoveProductViewModel: BaseViewModel
    {
        #region Fields
        private readonly Inventory _inventory;
        private string _productIDText;
        private UIElement _productDataContentControl;
        #endregion

        #region Properties
        public string ProductIDText
        {
            get => _productIDText;
            set
            {
                _productIDText = value;
                RaiseOnPropertyChanged(nameof(ProductIDText));
            }
        }
        public UIElement ProductDataContentControl
        {
            get => _productDataContentControl;
            set
            {
                _productDataContentControl = value;
                RaiseOnPropertyChanged(nameof(ProductDataContentControl));
            }
        }
        public ICommand SearchCommand { get; }
        public ICommand RemoveProductCommand { get; }
        public ICommand CancelCommand { get; }
        #endregion

        #region Methods

        #endregion

        public RemoveProductViewModel(Inventory inventory, NavigationStore navigationStore, Func<MainMenuViewModel> createMainMenuViewModel)
        {
            SearchCommand = new SearchProductCommand();
            RemoveProductCommand = new RemoveProductCommand();
            CancelCommand = new NavigateCommand(navigationStore, createMainMenuViewModel);
        }
    }
}
