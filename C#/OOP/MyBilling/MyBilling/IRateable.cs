using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    public interface IRateable
    {
        string Index(params object[] RatingInput);
    }
}
