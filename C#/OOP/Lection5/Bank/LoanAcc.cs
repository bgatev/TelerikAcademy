using System;
using System.Linq;

namespace Bank
{
    public class LoanAcc : Account, IAccount
    {
        public LoanAcc(Customer customer, double rate) : base(customer, rate)
        {
        }

        public void DepositMoney(double money)
        {
            this.Balance += money;
        }

        public override double CalculateRateforPeriod(int months)
        {
            double result = this.Balance * this.Rate;

            if (this.AccCustomer.GetType().Name == "IndividualCustomer")
            {
                if (months > 3) months -= 3;
                else months = 0;
            }
            else if (this.AccCustomer.GetType().Name == "CompanyCustomer")
            {
                if (months > 2) months -= 2;
                else months = 0;
            }

            result *= months;

            return result;
        }
    }
}
