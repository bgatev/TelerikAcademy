using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    public interface IChargeable
    {
        string CurrentLocation { get; set; }
        double Rate(int index);
    }
}
