using System;
using System.Linq;

namespace Bank
{
    public class DepositAcc : Account, IAccount
    {
        public DepositAcc(Customer customer, double rate) : base(customer, rate)
        {
        }

        public void DepositMoney(double money)
        {
            this.Balance += money;
        }

        public void WithDrawMoney(double money)
        {
            this.Balance -= money;
        }

        public override double CalculateRateforPeriod(int months)
        {
            double result = this.Balance * months;

            if (this.Balance > 0 && this.Balance < 1000) return 0;
            else return result *= this.Rate;
        }
    }
}
