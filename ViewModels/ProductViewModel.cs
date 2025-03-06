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
        public string Name {get; set;}
        public ProductCategoryEnum? Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        #endregion

        #region Constructor
        public ProductViewModel()
        {

        }
        #endregion

        #region Methods
        public abstract StackPanel ReturnStackPanel();
        public abstract StackPanel ReturnDataStackPanel();
        public abstract List<string> ReturnGridViewData();
        #endregion

    }
}
