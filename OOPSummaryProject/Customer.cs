using System;

namespace OOPSummaryProject
{
    class Customer
    {
        private static int numberOfCustomers = 0;

        private readonly int customerId;

        private readonly int customerNumber;

        public string Name { get; private set; }

        public string PhNumber { get; private set; }

        public int CustomerId
        {
            get { return customerId; }
        }
        public int CustomerNumber
        {
            get { return customerNumber; }
        }

        public Customer(int customerId, string name, string phNumber)
        {
            numberOfCustomers++;
            customerNumber = numberOfCustomers;

            this.customerId = customerId;
            Name = name;
            PhNumber = phNumber;
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            if(customer1 is null && customer2 is null)
            {
                return true;
            }
             else if (customer1 is null || customer2 is null)
            {
                return false;
            }
            else
            {
                return customer1.CustomerNumber == customer2.CustomerNumber;
            }
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(customer1 == customer2);
        }

        public override bool Equals(object obj) => obj is Customer customer && CustomerNumber == customer.CustomerNumber;

        public override int GetHashCode() => CustomerNumber.GetHashCode();

        internal string XMLSerialize()
        {
            return $@"<customer>
    <customer-id>{CustomerId}</customer-id>
    <customer-number>{CustomerNumber}</customer-number>
    <name>{Name}</name>    
    <ph-number>{PhNumber}</ph-number>
</customer>";
        }
    }
}
