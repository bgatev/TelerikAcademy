using System;
using System.Linq;

namespace Bank
{
    public abstract class Account
    {
        private double balance, rate;
        Customer accCustomer;

        public Account(Customer customer, double accRate)
        {
            this.accCustomer = customer;
            this.rate = accRate;
        }

        public double Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                if (value >= 0) this.balance = value;
                else throw new ArgumentException("Invalid Balance");
            }
        }

        public double Rate
        {
            get
            {
                return this.rate;
            }
            set
            {
                if (value > 0) this.rate = value;
                else throw new ArgumentException("Invalid Interest Rate");
            }
        }

        public Customer AccCustomer
        {
            get
            {
                return this.accCustomer;
            }
            set
            {
                if (value != null) this.accCustomer = value;
                else throw new ArgumentException("Invalid Customer");
            }
        }

        public virtual double CalculateRateforPeriod(int months)
        {
            return this.balance * this.rate * months;
        }
    }
}
