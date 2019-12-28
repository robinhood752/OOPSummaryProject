using System;

namespace OOPSummaryProject
{
    class Account
    {
        private const int MAX_MINUS_ALLOWED_MULTIPLIER = 3;

        private static int numberOfAcc = 0;

        private readonly int accountNumber;

        private readonly Customer accountOwner;

        private int maxMinusAllowed;

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        public int Balance { get; private set; }

        public Customer AccountOwner 
        { 
            get 
            {
                return accountOwner;
            }
        }

        public int MaxMinusAllowed 
        {
            get
            {
                return maxMinusAllowed;
            }
        }

        public Account(Customer customer, int monthlyIncome)
        {
            numberOfAcc++;
            accountNumber = numberOfAcc;

            accountOwner = customer;
            maxMinusAllowed = monthlyIncome * MAX_MINUS_ALLOWED_MULTIPLIER;
            Balance = 0;
        }

        public void Add(int amount)
        {
            Balance += amount;
        }

        public void Substract(int amount)
        {
            if (Balance - amount < MaxMinusAllowed)
            {
                throw new BalanceException();
            }

            Add(-amount);
        }

        public static bool operator ==(Account account1, Account account2)
        {
            if (account1 is null && account2 is null)
            {
                return true;
            }
            else if (account1 is null || account2 is null)
            {
                return false;
            }
            else
            {
                return account1.AccountNumber == account2.AccountNumber;
            }
        }

        public static bool operator !=(Account account1, Account account2)
        {
            return !(account1 == account2);
        }

        public override bool Equals(object obj) => obj is Account account && accountNumber == account.accountNumber;

        public override int GetHashCode() => accountNumber.GetHashCode();

        public static Account operator +(Account account1, Account account2)
        {
            if (account1.AccountOwner != account2.AccountOwner)
            {
                throw new NotSameCustomerException();
            }

            Account account = new Account(account1.AccountOwner, Math.Max(account1.MaxMinusAllowed, account2.MaxMinusAllowed))
            {
                Balance = account1.Balance + account2.Balance
            };

            account1.Balance = 0;
            account2.Balance = 0;

            return account;
        }

        public static Account operator +(Account account, int amount)
        {
            if (amount >= 0)
            {
                account.Add(amount);
            }
            else
            {
                account.Substract(amount);
            }
            
            return account;
        }

        public static Account operator -(Account account, int amount)
        {
            if (amount >= 0)
            {
                account.Substract(amount);
            }
            else
            {
                account.Add(amount);
            }

            return account;
        }
    }
}
