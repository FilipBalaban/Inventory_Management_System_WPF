using Inventory_Management_System_WPF.Exceptions;
using Inventory_Management_System_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inventory_Management_System_WPF.Commands
{
    public class RemoveProductCommand : BaseCommand
    {
        #region Fields
        private string _productId;
        private Inventory _inventory;
        #endregion

        #region Constructors
        public RemoveProductCommand(string id, Inventory inventory)
        {
            _productId = id;
            _inventory = inventory;
        }
        #endregion

        public override void Execute(object parameter)
        {
            string productName = "";
            try
            {
                if (_inventory.GetProductDictionary().ContainsKey(_productId))
                {
                    productName = _inventory.GetProductDictionary()[_productId].Name;
                }
                _inventory.RemoveProduct(_productId);
                MessageBox.Show($"{productName} with and ID {_productId} has been sucessfully removed to the inventory!", "Product removed", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (ProductNotInDictionaryException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public override bool CanExecute(object parameter)
        {
            if(_productId != null)
            {
                return true;
            }
            return false;
        }
    }
}
