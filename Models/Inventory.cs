using Inventory_Management_System_WPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.Models
{
    public class Inventory
    {
        #region Fields
        private Dictionary<string, Product> _productDictionary;
        #endregion

        #region Constructor
        public Inventory()
        {
            _productDictionary = new Dictionary<string, Product>();
        }
        #endregion

        #region Methods
        public void AddProduct(Product product)
        {
            if (_productDictionary.ContainsKey(product.ID))
            {
                throw new DuplicateProductInDictionaryException(product);
            }

            _productDictionary.Add(product.ID, product);
        }
        public void RemoveProduct(string productId)
        {
            if (!_productDictionary.ContainsKey(productId)){
                throw new ProductNotInDictionaryException(productId);
            }
            _productDictionary.Remove(productId);
        }
        public Dictionary<string, Product> GetProductDictionary(ProductCategoryEnum? category = null)
        {
            if (category.HasValue)
            {
                Dictionary<string, Product> tempDict = new Dictionary<string, Product>();
                foreach(Product p in _productDictionary.Values)
                {
                    if(p.Category == category)
                    {
                        tempDict.Add(p.ID, p);
                    }
                }
                return tempDict;
            }
            return _productDictionary;
        }
        #endregion
    }
}
