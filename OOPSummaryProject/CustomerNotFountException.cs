using System;

namespace OOPSummaryProject
{
    public class CustomerNotFountException : Exception
    {
        public CustomerNotFountException() : base() { }

        public CustomerNotFountException(string message) : base(message) { }

        public CustomerNotFountException(string message, Exception innerException) : base(message, innerException) { }
    }
}
