using System;
using System.Linq;

namespace Bank
{
    public class Customer
    {
        private string name;

        public Customer(string customerName)
        {
            this.name = customerName;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length > 5) this.name = value;
                else throw new ArgumentException("Invalid Name");
            }
        }
    }
}
