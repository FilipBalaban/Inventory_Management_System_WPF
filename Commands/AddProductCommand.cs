using Inventory_Management_System_WPF.Models;
using Inventory_Management_System_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
        public override bool CanExecute(object parameter)
        {
            if(_product != null)
            {
                return true;
            }
            return false;
        }
    }
}
