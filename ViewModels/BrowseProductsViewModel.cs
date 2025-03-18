using Inventory_Management_System_WPF.Commands;
using Inventory_Management_System_WPF.Exceptions;
using Inventory_Management_System_WPF.Models;
using Inventory_Management_System_WPF.Stores;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Inventory_Management_System_WPF.ViewModels
{
    public enum SelectedProductCategoryRadioEnum
    {
        All,
        Electronics,
        PerishableGoods,
        Clothing,
    };

    public class BrowseProductsViewModel: BaseViewModel
    {
        #region Fields
        private Inventory _inventory;
        private SelectedProductCategoryRadioEnum _selectedCategoryRadio;
        private UIElement _dynamicListView;
        #endregion

        #region Properties
        public SelectedProductCategoryRadioEnum SelectedCategoryRadio
        {
            get => _selectedCategoryRadio;
            set
            {
                _selectedCategoryRadio = value;
                Debug.Print($"{_selectedCategoryRadio}");
                RaiseOnPropertyChanged(nameof(SelectedCategoryRadio));
                ChangeGridView();
            }
        }
        public UIElement DynamicListView
        {
            get => _dynamicListView;
            set
            {
                _dynamicListView = value;
                RaiseOnPropertyChanged(nameof(DynamicListView));
            }
        }
        public ICommand ReturnCommand { get; }
        #endregion

        #region Constructor
        public BrowseProductsViewModel(Inventory inventory, NavigationStore navigationStore, Func<MainMenuViewModel> createMainMenuViewModel)
        {
            _inventory = inventory;
            ReturnCommand = new NavigateCommand(navigationStore, createMainMenuViewModel);
        }
        #endregion

        #region Methods
        private void ChangeGridView()
        {
            // Create list view
            ListView listView = new ListView();
            GridView gridView = CreateBaseGridView();
            listView.View = gridView;

            try
            {
                if (SelectedCategoryRadio == SelectedProductCategoryRadioEnum.All)
                {
                    if(_inventory.GetProductDictionary().Values.Count < 1)
                    {
                        throw new InvalidOperationException();
                    }
                    foreach (Product product in _inventory.GetProductDictionary().Values)
                    {
                        listView.Items.Add(new { Name = product.Name, Category = product.Category, Price = product.Price, Quantity = product.Quantity });
                    }
                } else if(SelectedCategoryRadio == SelectedProductCategoryRadioEnum.Electronics) 
                {
                    // Electronics
                    if (_inventory.GetProductDictionary(ProductCategoryEnum.Electronics).Values.Count < 1)
                    {
                        throw new InvalidOperationException();
                    }

                    GridViewColumn voltageColumn = new GridViewColumn()
                    {
                        Header = "Voltage",
                        DisplayMemberBinding = new Binding("Voltage")
                    };
                    gridView.Columns.Add(voltageColumn);

                    GridViewColumn batteryColumn = new GridViewColumn()
                    {
                        Header = "Battery Life",
                        DisplayMemberBinding = new Binding("BatteryLife")
                    };
                    gridView.Columns.Add(batteryColumn);

                    listView.View = gridView;

                    foreach (Electronics product in _inventory.GetProductDictionary(ProductCategoryEnum.Electronics).Values)                 {
                        listView.Items.Add(new { Name = product.Name, Category = product.Category, Price = product.Price, Quantity = product.Quantity, Voltage = product.Voltage, BatteryLife = product.BatteryLife });
                    }
                } else if(SelectedCategoryRadio == SelectedProductCategoryRadioEnum.PerishableGoods)
                {
                    // Perishable goods
                    if(_inventory.GetProductDictionary(ProductCategoryEnum.PerishableGoods).Values.Count < 1)
                    {
                        throw new InvalidOperationException();
                    }
                    GridViewColumn weightColumn = new GridViewColumn()
                    {
                        Header = "Weight",
                        DisplayMemberBinding = new Binding("Weight")
                    };
                    gridView.Columns.Add(weightColumn);

                    GridViewColumn caloriesColumn = new GridViewColumn()
                    {
                        Header = "Calories",
                        DisplayMemberBinding = new Binding("Calories")
                    };
                    gridView.Columns.Add(caloriesColumn);

                    GridViewColumn expirationDateColumn = new GridViewColumn()
                    {
                        Header = "Expiration Date",
                        DisplayMemberBinding = new Binding("ExpirationDate")
                    };
                    gridView.Columns.Add(expirationDateColumn);
                    listView.View = gridView;

                    foreach(PerishableGoods product in _inventory.GetProductDictionary(ProductCategoryEnum.PerishableGoods).Values)
                    {
                        listView.Items.Add(new { Name = product.Name, Category = product.Category, Price = product.Price, Quantity = product.Quantity, Weight = product.Weight, Calories = product.Calories, ExpirationDate = product.ExpirationDate.ToString("d") });
                    }
                }
                else if (SelectedCategoryRadio == SelectedProductCategoryRadioEnum.Clothing)
                {
                    // Clothing
                    if (_inventory.GetProductDictionary(ProductCategoryEnum.Clothing).Values.Count < 1)
                    {
                        throw new InvalidOperationException();
                    }
                    GridViewColumn sizeColumn = new GridViewColumn()
                    {
                        Header = "Size",
                        DisplayMemberBinding = new Binding("Size")
                    };
                    gridView.Columns.Add(sizeColumn);

                    GridViewColumn fabricColumn = new GridViewColumn()
                    {
                        Header = "Fabric",
                        DisplayMemberBinding = new Binding("Fabric")
                    };
                    gridView.Columns.Add(fabricColumn);

                    foreach (Clothing product in _inventory.GetProductDictionary(ProductCategoryEnum.Clothing).Values)
                    {
                        listView.Items.Add(new { Name = product.Name, Category = product.Category, Price = product.Price, Quantity = product.Quantity, Size = product.Size, Fabric = product.Fabric });
                    }
                }
                DynamicListView = listView;
            } catch (InvalidOperationException)
            {
                DynamicListView = new Label()
                {
                    Content = "No result"
                };
            }
        }
        private GridView CreateBaseGridView()
        {
            GridView gridView = new GridView();
            GridViewColumn nameColumn = new GridViewColumn()
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name"),
            };
            gridView.Columns.Add(nameColumn);
            
            GridViewColumn categoryColumn = new GridViewColumn()
            {
                Header = "Category",
                DisplayMemberBinding = new Binding("Category"),
            };
            gridView.Columns.Add(categoryColumn);

            GridViewColumn priceColumn = new GridViewColumn()
            {
                Header = "Price",
                DisplayMemberBinding = new Binding("Price"),
            };
            gridView.Columns.Add(priceColumn);

            GridViewColumn quantityColumn = new GridViewColumn()
            {
                Header = "Quantity",
                DisplayMemberBinding = new Binding("Quantity"),
            };
            gridView.Columns.Add(quantityColumn);

            return gridView;
        }
        #endregion
    }
}
