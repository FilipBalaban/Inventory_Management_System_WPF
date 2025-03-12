using Inventory_Management_System_WPF.Models;
using Inventory_Management_System_WPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Inventory_Management_System_WPF.Commands
{
    public class SearchProductCommand : BaseCommand
    {
        #region Fields
        private readonly Inventory _inventory;
        private string _productID;
        #endregion

        #region Properties
        public string ProductID
        {
            get => _productID;
            set
            {
                _productID = value;
                CanExecute(null);
            }
        }
        public RemoveProductViewModel RemoveProductVM { get; set; }
        #endregion

        #region Constructor
        public SearchProductCommand(RemoveProductViewModel removeProductVM, Inventory inventory, string productID)
        {
            RemoveProductVM = removeProductVM;
            _inventory = inventory;
            ProductID = productID;
        }
        #endregion

        #region Methods
        public override void Execute(object parameter)
        {
            RemoveProductVM.HasSearchBeenClicked = true;
            RemoveProductVM.ProductDataContentControl = GetProductDataContent();
        }
        public override bool CanExecute(object parameter)
        {
            if (string.IsNullOrEmpty(_productID))
            {
                return false;
            } 
            return true;
        }
        private UIElement GetProductDataContent()
        {
            if (!_inventory.GetProductDictionary().ContainsKey(_productID))
            {
                RemoveProductVM.RemoveProductCommand = new RemoveProductCommand(null, _inventory);
                return new Label()
                {
                    Content = "Product not found."
                };
            }
            RemoveProductVM.RemoveProductCommand = new RemoveProductCommand(_productID, _inventory);
            if (_inventory.GetProductDictionary()[_productID].GetType() == typeof(Electronics))
            {
                Electronics product = (Electronics)_inventory.GetProductDictionary()[_productID];
                return new ElectronicsViewModel(product.Name, product.Category, product.Price, product.Quantity, product.Voltage, product.BatteryLife).ReturnDataGrid() ;
            } else if (_inventory.GetProductDictionary()[_productID].GetType() == typeof(PerishableGoods))
            {
                PerishableGoods product = (PerishableGoods)_inventory.GetProductDictionary()[_productID];
                return new PerishableGoodsViewModel(product.Name, product.Category, product.Price, product.Quantity, product.Weight, product.Calories, product.ExpirationDate).ReturnDataGrid();
            }
            else
            {
                Clothing product = (Clothing)_inventory.GetProductDictionary()[_productID];
                return new ClothingViewModel(product.Name, product.Category, product.Price, product.Quantity, product.Size, product.Fabric).ReturnDataGrid();
            }
        }
        #endregion
    }
}
