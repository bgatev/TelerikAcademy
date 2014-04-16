using System;
using System.Linq;

namespace Bank
{
    public class MortageAcc : Account, IAccount
    {
        public MortageAcc(Customer customer, double rate) : base(customer, rate)
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
                if (months > 6) months -= 6;
                else months = 0;
            }
            else if (this.AccCustomer.GetType().Name == "CompanyCustomer")
            {
                if (months > 11) months -= 6;
                else result /= 2;
            }

            result *= months;

            return result;
        }
    }
}
