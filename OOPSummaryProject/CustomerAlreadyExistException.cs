using System;

namespace OOPSummaryProject
{
    public class CustomerAlreadyExistException : Exception
    {
        public CustomerAlreadyExistException() : base() { }

        public CustomerAlreadyExistException(string message) : base(message) { }

        public CustomerAlreadyExistException(string message, Exception innerException) : base(message, innerException) { }
    }
}
