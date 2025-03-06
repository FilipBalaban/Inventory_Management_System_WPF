using Inventory_Management_System_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.Exceptions
{
    public class DuplicateProductInDictionaryException : Exception
    {
        private readonly Product _product;

        public DuplicateProductInDictionaryException(Product product)
        {
            _product = product;
        }

        public DuplicateProductInDictionaryException(string message, Product product) : base(message)
        {
            _product = product;
        }

        public DuplicateProductInDictionaryException(string message, Exception innerException, Product product) : base(message, innerException)
        {
            _product = product;
        }

        protected DuplicateProductInDictionaryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"{_product.Name} with ID: {_product.ID} already exists in the product's dictionary.";
    }
}
