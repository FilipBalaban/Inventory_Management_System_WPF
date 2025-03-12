using Inventory_Management_System_WPF.Commands;
using Inventory_Management_System_WPF.Models;
using Inventory_Management_System_WPF.Stores;
using System;
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
        private ICommand _removeProductCommand;
        #endregion

        #region Properties
        public bool HasSearchBeenClicked { get; set; }
        public string ProductIDText
        {
            get => _productIDText;
            set
            {
                _productIDText = value;
                HasSearchBeenClicked = false;
                SearchCommand = new SearchProductCommand(this, _inventory, value);
                RemoveProductCommand = new RemoveProductCommand(null, null);
                RaiseOnPropertyChanged(nameof(ProductIDText));
                RaiseOnPropertyChanged(nameof(SearchCommand));
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
        public SearchProductCommand SearchCommand { get; private set; }
        public ICommand RemoveProductCommand
        {
            get => _removeProductCommand;
            set
            {
                _removeProductCommand = value;
                if (_removeProductCommand != null)
                {
                    RaiseOnPropertyChanged(nameof(RemoveProductCommand));
                }
                
            }
        }
        public ICommand CancelCommand { get; }
        #endregion


        #region Constructor
        public RemoveProductViewModel(Inventory inventory, NavigationStore navigationStore, Func<MainMenuViewModel> createMainMenuViewModel)
        {
            _inventory = inventory;
            SearchCommand = new SearchProductCommand(this, _inventory, _productIDText);
            _removeProductCommand = new RemoveProductCommand(null, _inventory);
            CancelCommand = new NavigateCommand(navigationStore, createMainMenuViewModel);
        }
        #endregion
    }
}
