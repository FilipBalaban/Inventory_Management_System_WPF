using Inventory_Management_System_WPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.Models
{
    public class PerishableGoods : Product
    {
        #region Events
        public event Action OnHasExpired;
        #endregion

        #region Fields
        private int _calories;
        private double _weight;
        private DateTime _expirationDate;
        #endregion

        #region Properties
        public int Calories
        {
            get => _calories;
            set
            {
                if(value < 0)
                {
                    throw new ProductInvalidPropertyException("Product cannot have negative number of calories!");
                }
                _calories = value;
            }
        }
        public double Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                {
                    throw new ProductInvalidPropertyException("Product cannot have negative number of calories!");
                }
                _weight = value;
            }
        }
        public DateTime ExpirationDate
        {
            get => _expirationDate;
            set
            {
                if (value < DateTime.Now)
                {
                    RaiseOnHasExpired();
                }
            }
        }
        #endregion

        #region Constructor
        public PerishableGoods(string name, double price, int quantity, ProductCategoryEnum category, int calories, double weight, DateTime expDate) : base(name, price, quantity, category)
        {
            Calories = calories;
            Weight = weight;
            ExpirationDate = expDate;
        }
        #endregion

        #region Methods
        protected virtual void RaiseOnHasExpired()
        {
            OnHasExpired?.Invoke();
        }
        #endregion
    }
}
