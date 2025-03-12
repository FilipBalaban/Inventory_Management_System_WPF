using Inventory_Management_System_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public ProductViewModel(string name, ProductCategoryEnum category, double price, int quantity)
        {
            RequiredPropertiesFilled = false;
        }
        #endregion

        #region Methods
        public abstract StackPanel ReturnStackPanel();
        public abstract Grid ReturnDataGrid();
        public abstract List<string> ReturnGridViewData();
        protected virtual Grid CreateBaseDataGrid()
        {
            Grid grid = new Grid();
            grid.Width = 414;
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) });
            grid.RowDefinitions.Add(new RowDefinition());

            // Name 
            TextBlock nameBlock = new TextBlock()
            {
                Text = $"Product: {Name}"
            };
            grid.Children.Add(nameBlock);

            // Category
            TextBlock categoryBlock = new TextBlock()
            {
                Text = $"Category: {Category.ToString()}"
            };
            Grid.SetColumn(categoryBlock, 2);
            grid.Children.Add(categoryBlock);

            // Price
            TextBlock priceBlock = new TextBlock()
            {
                Text = $"Price: {Price}"
            };
            Grid.SetColumn(priceBlock, 0);
            Grid.SetRow(priceBlock, 2);
            grid.Children.Add(priceBlock);

            // Quantity
            TextBlock quantityBlock = new TextBlock()
            {
                Text = $"Quantity: {Quantity}"
            };
            Grid.SetColumn(quantityBlock, 2);
            Grid.SetRow(quantityBlock, 2);
            grid.Children.Add(quantityBlock);

            return grid;
        }
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
