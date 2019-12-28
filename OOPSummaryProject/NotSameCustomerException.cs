using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSummaryProject
{
    public class NotSameCustomerException : Exception
    {
        public NotSameCustomerException() : base() { }

        public NotSameCustomerException(string message) : base(message) { }

        public NotSameCustomerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
