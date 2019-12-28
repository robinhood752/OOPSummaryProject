using System;

namespace OOPSummaryProject
{
    public class NotSameCustomerException : Exception
    {
        public NotSameCustomerException() : base() { }

        public NotSameCustomerException(string message) : base(message) { }

        public NotSameCustomerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
