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
        #region Fields
        private readonly Product _product;
        private string _name;
        private ProductCategoryEnum? _category;
        private double? _price;
        private int? _quantity;
        private bool _requiredPropertiesFilled;
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                CheckFilledProperties();
            }
        }
        public ProductCategoryEnum? Category
        {
            get => _category;
            set
            {
                _category = value;
                CheckFilledProperties();
            }
        }
        public double? Price
        {
            get => _price;
            set
            {
                _price = value;
                CheckFilledProperties();
            }
        }

        public int? Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                CheckFilledProperties();
            }
        }

        public bool RequiredPropertiesFilled
        {
            get => _requiredPropertiesFilled;
            protected set
            {
                _requiredPropertiesFilled = value;
                RaiseOnRequiredFilledPropertiesChanged();
            }
        }
        #endregion

        #region Constructor
        public ProductViewModel()
        {
            RequiredPropertiesFilled = false;
        }
        #endregion

        #region Methods
        public abstract StackPanel ReturnStackPanel();
        public abstract StackPanel ReturnDataStackPanel();
        public abstract List<string> ReturnGridViewData();
        protected virtual void CheckFilledProperties()
        {
            if(!string.IsNullOrEmpty(_name) && _category.HasValue && _price.HasValue && _quantity.HasValue)
            {
                RequiredPropertiesFilled = true;
            }
            else
            {
                RequiredPropertiesFilled = false;
            }
        }
        public event Action OnRequiredFilledPropertiesChanged;

        protected virtual void RaiseOnRequiredFilledPropertiesChanged()
        {
            OnRequiredFilledPropertiesChanged?.Invoke();
        }
        #endregion



    }
}
