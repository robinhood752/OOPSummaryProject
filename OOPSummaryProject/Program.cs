using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSummaryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(123, "Michael Babich", "0558862926");
            Customer customer2 = new Customer(1234, "Jonh Doe", "0000000000");

            Bank bank = new Bank("Some Bank", "Some Address");

            bank.AddNewCustomer(customer1);

            bank.OpenNewAccount(new Account(customer1, 15000), customer1);
            bank.OpenNewAccount(new Account(customer2, 17500), customer2);
            bank.OpenNewAccount(new Account(customer1, 20000), customer1);

            bank.Withdraw()
        }
    }
}
