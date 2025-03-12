using Inventory_Management_System_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Media3D;

namespace Inventory_Management_System_WPF.ViewModels
{
    public class ClothingViewModel : ProductViewModel
    {
        #region Fields
        private ClothingSizeEnum? _selectedSize;
        private ClothingFabricEnum? _selectedFabric;

        #endregion

        #region Properties
        public ClothingSizeEnum? Size
        {
            get => _selectedSize;
            set
            {
                _selectedSize = value;
                CheckFilledProperties();
            }
        }
        public ClothingFabricEnum? Fabric
        {
            get => _selectedFabric;
            set
            {
                _selectedFabric = value;
                CheckFilledProperties();
            }
        }
        public List<ClothingSizeEnum> DisplaySize { get; }
        public List<ClothingFabricEnum> DisplayFabric { get; }
        #endregion

        #region Constructors
        public ClothingViewModel()
        {
            DisplaySize = Enum.GetValues(typeof(ClothingSizeEnum)).Cast<ClothingSizeEnum>().ToList();
            DisplayFabric = Enum.GetValues(typeof(ClothingFabricEnum)).Cast<ClothingFabricEnum>().ToList();
        }
        public ClothingViewModel(string name, ProductCategoryEnum category, double price, int quantity, ClothingSizeEnum size, ClothingFabricEnum fabric) : base(name, category, price, quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
            Size = size;
            Fabric = fabric;

            DisplaySize = Enum.GetValues(typeof(ClothingSizeEnum)).Cast<ClothingSizeEnum>().ToList();
            DisplayFabric = Enum.GetValues(typeof(ClothingFabricEnum)).Cast<ClothingFabricEnum>().ToList();
        }
        #endregion

        #region Methods
        public override Grid ReturnDataGrid()
        {
            Grid grid = CreateBaseDataGrid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) });
            grid.RowDefinitions.Add(new RowDefinition()); // 4

            // Size
            TextBlock sizeBlock = new TextBlock()
            {
                Text = $"Size: {Size.ToString()}"
            };
            Grid.SetColumn(sizeBlock, 0);
            Grid.SetRow(sizeBlock, 4);
            grid.Children.Add(sizeBlock);

            // Fabric
            TextBlock fabricBlock = new TextBlock()
            {
                Text = $"Fabric: {Fabric.ToString()}"
            };
            Grid.SetColumn(fabricBlock, 2);
            Grid.SetRow(fabricBlock, 4);
            grid.Children.Add(fabricBlock);

            return grid;
        }

        public override List<string> ReturnGridViewData()
        {
            throw new NotImplementedException();
        }

        public override StackPanel ReturnStackPanel()
        {
            // Size
            Binding sizeSourceBinding = new Binding("DisplaySize")
            {
                Source = this,
                Mode = BindingMode.OneWay,
            };
            Binding sizeSelectedBinging = new Binding("Size")
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            };

            ComboBox sizeComboBox = new ComboBox();
            sizeComboBox.SetBinding(ComboBox.ItemsSourceProperty, sizeSourceBinding);
            sizeComboBox.SetBinding(ComboBox.SelectedItemProperty, sizeSelectedBinging);

            // Fabric
            Binding fabricSourceBinding = new Binding("DisplayFabric")
            {
                Source = this,
                Mode = BindingMode.OneWay,
            };
            Binding fabricSelectedBinging = new Binding("Fabric")
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            };

            ComboBox fabricComboBox = new ComboBox();
            fabricComboBox.SetBinding(ComboBox.ItemsSourceProperty, fabricSourceBinding);
            fabricComboBox.SetBinding(ComboBox.SelectedItemProperty, fabricSelectedBinging);

            StackPanel stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new StackPanel
                    {
                        Children =
                        {
                            new TextBlock
                            {
                                Text="Size"
                            },
                            sizeComboBox
                        }
                    },
                    new StackPanel
                    {
                        Children =
                        {
                            new TextBlock
                            {
                                Text="Fabric"
                            },
                            fabricComboBox
                        }
                    },
                }
            };
            return stackPanel;
        }
        protected override void CheckFilledProperties()
        {
            base.CheckFilledProperties();
            if(RequiredPropertiesFilled && _selectedSize.HasValue && _selectedFabric.HasValue)
            {
                RequiredPropertiesFilled = true;
            }
            else
            {
                RequiredPropertiesFilled = false;
            }
        }
        #endregion
    }
}
