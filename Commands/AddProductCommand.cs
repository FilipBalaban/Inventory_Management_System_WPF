using Inventory_Management_System_WPF.Models;
using Inventory_Management_System_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inventory_Management_System_WPF.Commands
{
    public class AddProductCommand : BaseCommand
    {
        private Inventory _inventory;
        private ProductViewModel _product;

        public AddProductCommand(Inventory inventory, ProductViewModel product)
        {
            _inventory = inventory;
            _product = product;
        }
        public override void Execute(object parameter)
        {
            if (_product.GetType() == typeof(ElectronicsViewModel))
            {
                Debug.Print("Voltage: " + (double)((ElectronicsViewModel)_product).Voltage);
                Electronics product = new Electronics(_product.Name, (double)_product.Price, (int)_product.Quantity, (ProductCategoryEnum)_product.Category, (double)((ElectronicsViewModel)_product).Voltage, (double)((ElectronicsViewModel)_product).BatteryLife);
                AddProductAndDisplay(product);
            } else if(_product.GetType() == typeof(PerishableGoodsViewModel))
            {
                PerishableGoods product = new PerishableGoods(_product.Name, (double)_product.Price, (int)_product.Quantity, (ProductCategoryEnum)_product.Category, (int)((PerishableGoodsViewModel)_product).Calories, (double)((PerishableGoodsViewModel)_product).Weight,(DateTime)((PerishableGoodsViewModel)_product).ExpirationDate);
                Debug.Print($"Date: {product.ExpirationDate}");

                AddProductAndDisplay(product);
            }
            else
            {
                Clothing product = new Clothing(_product.Name, (double)_product.Price, (int)_product.Quantity, (ProductCategoryEnum)_product.Category, (ClothingSizeEnum)((ClothingViewModel)_product).Size, (ClothingFabricEnum)((ClothingViewModel)_product).Fabric);
                AddProductAndDisplay(product);
            }
        }
        private void AddProductAndDisplay(Product product)
        {
            _inventory.AddProduct(product);
            MessageBox.Show($"{product.Name} with and ID {product.ID} has been sucessfully added to the inventory!", "Product added", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public override bool CanExecute(object parameter)
        {
            if(_product != null && _product.RequiredPropertiesFilled)
            {
                return true;
            }
            return false;
        }
    }
}
