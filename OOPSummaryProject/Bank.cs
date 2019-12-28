using System;
using System.Collections.Generic;

namespace OOPSummaryProject
{
    class Bank : IBank
    {
        private List<Account> accounts = new List<Account>();

        private List<Customer> customers = new List<Customer>();

        private Dictionary<int, Customer> customerById = new Dictionary<int, Customer>();

        private Dictionary<int, Customer> customerByNumber = new Dictionary<int, Customer>();

        private Dictionary<int, Account> accountByNumber = new Dictionary<int, Account>();

        private Dictionary<Customer, List<Account>> accountsByCustomer = new Dictionary<Customer, List<Account>>();

        private int totalMoneyBank = 0;

        private int profits = 0;

        public Bank(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; }

        public string Address { get; }

        public int CustomerCount { get; private set; }

        public Customer GetCustomerById(int customerId) => customerById[customerId];

        public Customer GetCustomerByNumber(int customerNumber) => customerByNumber[customerNumber];

        public Account GetAccountByNumber(int accountNumber) => accountByNumber[accountNumber];

        public List<Account> GetAccountsByCustomer(Customer customer) => accountsByCustomer[customer];

        public void AddNewCustomer(Customer customer)
        {
            if (customers.Contains(customer))
            {
                throw new CustomerAlreadyExistException();
            }

            customers.Add(customer);
            customerById.Add(customer.CustomerId, customer);
            customerByNumber.Add(customer.CustomerNumber, customer);
            accountsByCustomer.Add(customer, new List<Account>());
            CustomerCount++;
        }

        public void OpenNewAccount(Account account, Customer customer)
        {
            if (accounts.Contains(account))
            {
                throw new AccountAlreadyExistException();
            }

            if (account.AccountOwner != customer)
            {
                throw new NotSameCustomerException();
            }

            accounts.Add(account);
            accountByNumber.Add(account.AccountNumber, account);

            if (!accountsByCustomer.ContainsKey(customer))
            {
                AddNewCustomer(customer);
            }

            accountsByCustomer[customer].Add(account);
        }

        public int Deposit(Account account, int amount)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotFoundException();
            }

            account.Add(amount);
            totalMoneyBank += amount;

            return account.Balance;
        }

        public int Withdraw(Account account, int amount)
        {
            if (!accounts.Contains(account))
            {
                throw new AccountNotFoundException();
            }

            try
            {
                account.Substract(amount);
                totalMoneyBank -= amount;
            }
            catch (BalanceException)
            {
                Console.WriteLine("Balance Exception");
            }

            return account.Balance;
        }

        public int GetCustomerTotalBalance(Customer customer)
        {
            int totalBalance = 0;
            GetAccountsByCustomer(customer)
                .ForEach(acc => totalBalance += acc.Balance);
            return totalBalance;
        }

        public void CloseAccount(Account account, Customer customer)
        {
            accountsByCustomer[customer].Add(account);

            if (!accounts.Contains(account))
            {
                throw new AccountNotFoundException();
            }

            if (account.AccountOwner != customer)
            {
                throw new NotSameCustomerException();
            }

            accounts.Remove(account);
            accountByNumber.Remove(account.AccountNumber);
            accountsByCustomer[customer].Remove(account);
        }

        public void ChargeAnnualCommission(float percentage)
        {
            if (percentage < 0 || percentage >= 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            accounts.ForEach(account =>
            {
                int commission;

                if (account.Balance >= 0)
                {
                    commission = (int)Math.Floor(account.Balance * percentage / 100);
                }
                else
                {
                    commission = (int)Math.Floor(-account.Balance * 2 * percentage / 100);
                }

                try
                {
                    account.Substract(commission);
                    profits += commission;
                }
                catch (BalanceException)
                {
                    Console.WriteLine("Balance Exception");
                }
            });
        }

        public void JoinAccounts(Account account1, Account account2)
        {
            if (account1 == account2)
            {
                throw new AccountAlreadyExistException();
            }

            if (account1.AccountOwner != account2.AccountOwner)
            {
                throw new NotSameCustomerException();
            }

            OpenNewAccount(account1 + account2, account1.AccountOwner);

            CloseAccount(account1, account1.AccountOwner);
            CloseAccount(account2, account2.AccountOwner);
        }

        public string XMLSerialize()
        {
            string serializedCustomers = string.Empty;
            customers.ForEach(customer => serializedCustomers += customer.XMLSerialize() + Environment.NewLine);
            AddIndent(ref serializedCustomers, 8);

            string serializedAccounts = string.Empty;
            accounts.ForEach(account => serializedAccounts += account.XMLSerialize() + Environment.NewLine);
            AddIndent(ref serializedAccounts, 8);

            return $@"<bank>
    <name>{Name}</name>
    <address>{Address}</address>
    <customer-count>{CustomerCount}</customer-count>
    <total-money>{totalMoneyBank}</total-money>
    <profits>{profits}</profits>
    <customers>
{serializedCustomers}
    </customers>
    <accounts>
{serializedAccounts}
    </accounts>
</bank>";
        }

        private void AddIndent(ref string text, int indent)
        {
            string[] serializedCustomersArr = text.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            text = string.Empty;

            for (int i = 0; i < serializedCustomersArr.Length; i++)
            {
                for (int space = 0; space < indent; space++)
                {
                    text += " ";
                }

                text += serializedCustomersArr[i];

                if (i < serializedCustomersArr.Length - 1)
                { 
                    text += Environment.NewLine;
                } 
            }
        }
    }
}
