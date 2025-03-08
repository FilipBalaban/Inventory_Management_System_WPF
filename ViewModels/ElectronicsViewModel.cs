using Inventory_Management_System_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        #region Methods
        public override StackPanel ReturnDataStackPanel()
        {
            throw new NotImplementedException();
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
            Binding voltageBinding = new Binding("Voltage")
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger=UpdateSourceTrigger.PropertyChanged
            };
            voltageBox.SetBinding(TextBox.TextProperty, voltageBinding);
           
            TextBlock batteryBlock = new TextBlock
            {
                Text = "Battery life"
            };
            TextBox batteryBox = new TextBox();
            Binding batteryBinding = new Binding("BatteryLife")
            {
                Source = this,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            batteryBox.SetBinding(TextBox.TextProperty, batteryBinding);

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
