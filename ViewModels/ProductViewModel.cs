using Inventory_Management_System_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Inventory_Management_System_WPF.ViewModels
{
    public abstract class ProductViewModel : BaseViewModel
    {
        #region Properties
        private readonly Product _product;
        public string Name => _product.Name;
        public ProductCategoryEnum Category => _product.Category;
        public double Price => _product.Price;
        public int Quantity => _product.Quantity;
        #endregion

        #region Constructor
        public ProductViewModel(Product product)
        {
            _product = product;
        }
        #endregion

        #region Methods
        public abstract StackPanel ReturnStackPanel();
        public abstract StackPanel ReturnDataStackPanel();
        public abstract List<string> ReturnGridViewData();
        #endregion

    }
}
