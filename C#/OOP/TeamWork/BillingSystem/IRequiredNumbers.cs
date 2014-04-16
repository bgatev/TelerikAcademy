using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public interface IRequiredNumbers
    {
        string MSISDN { get; set; }
        string BParty { get; set; }
    }
}
