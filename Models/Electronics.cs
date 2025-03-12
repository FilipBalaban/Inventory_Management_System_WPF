using Inventory_Management_System_WPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.Models
{
    public class Electronics : Product
    {
        #region Fields
        private double _voltage;
        private double _batteryLife;
        #endregion

        #region Properies
        public double Voltage
        {
            get => _voltage;
            set
            {
                if(value < 0)
                {
                    throw new ProductInvalidPropertyException("Electronic product cannot have a negative voltage.");
                }
                _voltage = value;
            }
        }
        public double BatteryLife
        {
            get => _batteryLife;
            set
            {
                if (value < 0)
                {
                    throw new ProductInvalidPropertyException("Electronic product cannot have a negative battery life.");
                }
                _batteryLife = value;
            }
        }
        #endregion

        #region Constructor
        public Electronics(string name, double price, int quantity, ProductCategoryEnum category, double voltage, double batteryLife) : base(name, price, quantity, category)
        {
            Voltage = voltage;
            BatteryLife = batteryLife;
        }
        #endregion
    }
}
