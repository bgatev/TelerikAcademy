using System;
using System.Linq;

namespace Bank
{
    class MainProgram
    {
        static void Main()  //Please take in mind that the formula for interest is just an example to show how to overrdide methods
        {
            Customer indCust = new IndividualCustomer("Ivan Ivanov","1234567890");
            Customer companyCust = new CompanyCustomer("Golemite EOOD", "555666777");
            LoanAcc indLoanAcc = new LoanAcc(indCust, 3.4);
            LoanAcc companyLoanAcc = new LoanAcc(companyCust, 3.4);
            DepositAcc depAcc = new DepositAcc(indCust, 4);
            MortageAcc indMortAcc = new MortageAcc(indCust, 5);
            MortageAcc companyMortAcc = new MortageAcc(companyCust, 5);
            
            int loanPeriod = 13;
            indLoanAcc.DepositMoney(100);
            double indLoanRate = indLoanAcc.CalculateRateforPeriod(loanPeriod);
            Console.WriteLine("The balance for {0} of {1} - {2} with monthly rate {3} % for {4} months is {5} BGN. The start balance is {6} BGN.",
                indLoanAcc.GetType().Name, indCust.GetType().Name, indCust.Name, indLoanAcc.Rate, loanPeriod, indLoanRate,indLoanAcc.Balance);

            Console.WriteLine();
            companyLoanAcc.DepositMoney(200);
            double companyLoanRate = companyLoanAcc.CalculateRateforPeriod(loanPeriod);
            Console.WriteLine("The balance for {0} of {1} - {2} with monthly rate {3} % for {4} months is {5} BGN. The start balance is {6} BGN.",
                companyLoanAcc.GetType().Name, companyCust.GetType().Name, companyCust.Name, companyLoanAcc.Rate, loanPeriod, companyLoanRate,companyLoanAcc.Balance);

            Console.WriteLine();
            depAcc.DepositMoney(2000);
            depAcc.WithDrawMoney(100);
            int depPeriod = 3;
            double indDepRate = depAcc.CalculateRateforPeriod(depPeriod);
            Console.WriteLine("The balance for {0} of {1} - {2} with balance {3} BGN and monthly rate {4} % for {5} months is {6} BGN",
                depAcc.GetType().Name, indCust.GetType().Name, indCust.Name, depAcc.Balance,depAcc.Rate, depPeriod,indDepRate);

            Console.WriteLine();
            int mortagePeriod = 7;
            indMortAcc.DepositMoney(300);
            double indMortRate = indMortAcc.CalculateRateforPeriod(mortagePeriod);
            Console.WriteLine("The balance for {0} of {1} - {2} with monthly rate {3} % for {4} months is {5} BGN. The start balance is {6} BGN.",
                indMortAcc.GetType().Name, indCust.GetType().Name, indCust.Name, indMortAcc.Rate, mortagePeriod, indMortRate,indMortAcc.Balance);

            Console.WriteLine();
            companyMortAcc.DepositMoney(350);
            double companyMortRate = companyMortAcc.CalculateRateforPeriod(mortagePeriod);
            Console.WriteLine("The balance for {0} of {1} - {2} with monthly rate {3} % for {4} months is {5} BGN. The start balance is {6} BGN.",
                companyMortAcc.GetType().Name, companyCust.GetType().Name, companyCust.Name, companyMortAcc.Rate, mortagePeriod, companyMortRate,companyMortAcc.Balance);

        }
    }
}
