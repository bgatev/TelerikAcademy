using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    public class BillingArgExc:ArgumentException
    {
        public BillingArgExc()
        {
            Console.WriteLine("Main Info");
        }

        public BillingArgExc(string message):base(message)
        {
            Console.WriteLine("Basic");
        }
        public BillingArgExc(string message, Exception innerException): base (message, innerException)
        {
            Console.WriteLine("Inner");
        }
    }
}
