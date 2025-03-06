using Inventory_Management_System_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.Exceptions
{
    public class ProductNotInDictionaryException : Exception
    {
        private readonly Product _product;

        public ProductNotInDictionaryException(Product product)
        {
            _product = product;
        }

        public ProductNotInDictionaryException(string message, Product product) : base(message)
        {
            _product = product;
        }

        public ProductNotInDictionaryException(string message, Exception innerException, Product product) : base(message, innerException)
        {
            _product = product;
        }

        protected ProductNotInDictionaryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"{_product.Name} with ID: {_product.ID} does not exist in the product's dictionary.";
    }
}
