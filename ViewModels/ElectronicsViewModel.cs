using Inventory_Management_System_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Inventory_Management_System_WPF.ViewModels
{
    public class ElectronicsViewModel : ProductViewModel
    {
        #region Fields
        private double? _voltage;
        private double? _batteryLife;
        #endregion

        #region Properites
        public double? Voltage
        {
            get => _voltage;
            set
            {
                _voltage = value;
                CheckFilledProperties();
            }
        }
        public double? BatteryLife
        {
            get => _batteryLife;
            set
            {
                _batteryLife = value;
                CheckFilledProperties();
            }
        }
        #endregion

        #region Constructors
        public ElectronicsViewModel()
        {

        }
        public ElectronicsViewModel(string name, ProductCategoryEnum category, double price, int quantity, double voltage, double batteryLife): base(name, category, price, quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
            Voltage = voltage;
            BatteryLife = batteryLife;
        }
        #endregion

        #region Methods
        public override Grid ReturnDataGrid()
        {
            Grid grid = CreateBaseDataGrid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(8) });
            grid.RowDefinitions.Add(new RowDefinition()); // 4

            // Voltage
            TextBlock voltageBlock = new TextBlock()
            {
                Text = $"Voltage: {Voltage.ToString()}"
            };
            Grid.SetColumn(voltageBlock, 0);
            Grid.SetRow(voltageBlock, 4);
            grid.Children.Add(voltageBlock);

            // Battery Life
            TextBlock batteryBlock = new TextBlock()
            {
                Text = $"Battery Life: {BatteryLife.ToString()}"
            };
            Grid.SetColumn(batteryBlock, 2);
            Grid.SetRow(batteryBlock, 4);
            grid.Children.Add(batteryBlock);

            return grid;
        }

        public override List<string> ReturnGridViewData()
        {
            throw new NotImplementedException();
        }
        
        public override StackPanel ReturnStackPanel()
        {
            TextBlock voltageBlock = new TextBlock
            {
                Text = "Voltage"
            };
            TextBox voltageBox = new TextBox();
            voltageBox.SetBinding(TextBox.TextProperty, new Binding("Voltage")
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });
           
            TextBlock batteryBlock = new TextBlock
            {
                Text = "Battery life"
            };
            TextBox batteryBox = new TextBox();
            batteryBox.SetBinding(TextBox.TextProperty, new Binding("BatteryLife")
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

            StackPanel stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new StackPanel()
                    {
                        Children =
                        {
                            voltageBlock,
                            voltageBox,
                        },
                        
                    },
                    new StackPanel()
                    {
                        Children =
                        {
                            batteryBlock,
                            batteryBox,
                        },
                    }
                }
            };
            return stackPanel;
        }
        protected override void CheckFilledProperties()
        {
            base.CheckFilledProperties();
            if(RequiredPropertiesFilled == true && _voltage.HasValue && _batteryLife.HasValue){
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
