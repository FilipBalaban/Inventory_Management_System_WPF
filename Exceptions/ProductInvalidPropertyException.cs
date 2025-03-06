using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System_WPF.Exceptions
{
    public class ProductInvalidPropertyException : Exception
    {   
        public ProductInvalidPropertyException()
        {
        }

        public ProductInvalidPropertyException(string message) : base(message)
        {
        }

        public ProductInvalidPropertyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductInvalidPropertyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
