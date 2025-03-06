using Inventory_Management_System_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Inventory_Management_System_WPF.ViewModels
{
    public class ElectronicsViewModel : ProductViewModel
    {
        #region Properites
        public double Voltage { get; set; }
        public double BatteryLife { get; set; }
        #endregion

        #region Methods
        public override StackPanel ReturnDataStackPanel()
        {
            throw new NotImplementedException();

            TextBlock voltageBlock = new TextBlock
            {
                Text = "Voltage"
            };
            TextBox voltageBox = new TextBox();

            TextBlock batteryBlock = new TextBlock
             {
                 Text = "Battery life"
             };
            TextBox batteryBox = new TextBox();

            StackPanel verticalStackPanel1 = new StackPanel
            {
                Orientation = Orientation.Vertical
            };
            StackPanel verticalStackPanel2 = new StackPanel
            {
                Orientation = Orientation.Vertical
            };

            verticalStackPanel1.Children.Add(voltageBlock);
            verticalStackPanel1.Children.Add(voltageBox);
            verticalStackPanel2.Children.Add(batteryBlock);
            verticalStackPanel2.Children.Add(batteryBox);

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.Children.Add(verticalStackPanel1);
            grid.Children.Add(verticalStackPanel2);
        }

        public override List<string> ReturnGridViewData()
        {
            throw new NotImplementedException();
        }

        public override StackPanel ReturnStackPanel()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
