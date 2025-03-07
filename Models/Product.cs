using Inventory_Management_System_WPF.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.Models
{
    public enum ProductCategoryEnum
    {
        PerishableGoods,
        Electronics,
        Clothing
    }
    public class Product
    {
        #region Events
        public event Action OnNoQuantity;
        #endregion

        #region Fields
        private static int _clothingObjectCounter;
        private static int _electronicsObjectCounter;
        private static int _perishableGoodsObjectCounter;
        // Could be editable UI properties in the future
        private string _name;
        private double _price;
        private int _quantity;
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ProductInvalidPropertyException("Product name cannot be an empty string!");
                }
                _name = char.ToUpper(value[0]) + value.Substring(1);
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ProductInvalidPropertyException("Product price cannot be less than zero!");
                }
                _price = value;
            }
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value <= 0)
                {
                    RaiseOnNoQuantity();
                }
                _quantity = value;
            }
        }
        public ProductCategoryEnum Category { get;}
        public string ID { get; private set; }
        #endregion


        #region Constructor
        public Product(string name, double price, int quantity, ProductCategoryEnum category)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            GenerateID();
        }
        #endregion

        #region Methods
        private void GenerateID()
        {
            switch (Category)
            {
                case ProductCategoryEnum.PerishableGoods:
                    _perishableGoodsObjectCounter++;
                    ID = $"pg.{_perishableGoodsObjectCounter.ToString().PadLeft(4, '0')}";
                    break;
                case ProductCategoryEnum.Electronics:
                    _electronicsObjectCounter++;
                    ID = $"el.{_electronicsObjectCounter.ToString().PadLeft(4, '0')}";
                    break;
                case ProductCategoryEnum.Clothing:
                    _clothingObjectCounter++;
                    ID = $"cl.{_clothingObjectCounter.ToString().PadLeft(4, '0')}";
                    break;
            }
        }
        protected virtual void RaiseOnNoQuantity()
        {
            OnNoQuantity?.Invoke();
        }
        #endregion

    }
}
