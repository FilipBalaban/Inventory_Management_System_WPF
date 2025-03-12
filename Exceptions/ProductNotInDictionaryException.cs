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
        private readonly string _productId;

        public ProductNotInDictionaryException(string productId)
        {
            _productId = productId;
        }

        public ProductNotInDictionaryException(string message, string productId) : base(message)
        {
            _productId = productId;
        }

        public ProductNotInDictionaryException(string message, Exception innerException, string productId) : base(message, innerException)
        {
            _productId = productId;
        }

        protected ProductNotInDictionaryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"Product with an ID: {_productId} does not exist in the product's dictionary.";
    }
}
