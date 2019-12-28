using System;

namespace OOPSummaryProject
{
    public class BalanceException : Exception
    {
        public BalanceException() : base() { }

        public BalanceException(string message) : base(message) { }

        public BalanceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
