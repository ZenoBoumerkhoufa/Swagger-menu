using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class MenuItemException : Exception
    {
        public MenuItemException()
        {
        }

        public MenuItemException(string? message) : base(message)
        {
        }

        public MenuItemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MenuItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
