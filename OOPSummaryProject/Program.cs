using System;

namespace OOPSummaryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(123, "Michael Babich", "0558862926");
                Customer customer2 = new Customer(1234, "Jonh Doe", "0000000000");

                Account account1 = new Account(customer1, 15000);
                Account account2 = new Account(customer2, 17500);
                Account account3 = new Account(customer1, 20000);

                Bank bank = new Bank("Some Bank", "Some Address");

                bank.AddNewCustomer(customer1);

                bank.OpenNewAccount(account1, customer1);
                bank.OpenNewAccount(account2, customer2);
                bank.OpenNewAccount(account3, customer1);

                bank.Deposit(account1, 10000);
                bank.Deposit(account2, 15000);
                bank.Deposit(account3, 20000);

                bank.Withdraw(account2, 20000);

                bank.CloseAccount(account3, customer1);

                Console.WriteLine(bank.XMLSerialize());
            }
            catch (AccountAlreadyExistException)
            {
                Console.WriteLine("AccountAlreadyExistException");
            }
            catch (AccountNotFoundException)
            {
                Console.WriteLine("AccountNotFoundException");
            }
            catch (BalanceException)
            {
                Console.WriteLine("BalanceException");
            }
            catch (CustomerAlreadyExistException)
            {
                Console.WriteLine("CustomerAlreadyExistException");
            }
            catch (CustomerNotFountException) 
            {
                Console.WriteLine("CustomerNotFountException");
            }
            catch (NotSameCustomerException)
            {
                Console.WriteLine("NotSameCustomerException");
            }
        }
    }
}
