using System;

namespace OOPSummaryProject
{
    public class AccountAlreadyExistException : Exception
    {
        public AccountAlreadyExistException() : base() { }

        public AccountAlreadyExistException(string message) : base(message) { }

        public AccountAlreadyExistException(string message, Exception innerException) : base(message, innerException) { }
    }
}
