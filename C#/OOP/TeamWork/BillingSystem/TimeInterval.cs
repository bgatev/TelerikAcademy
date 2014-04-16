using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class TimeInterval : RatingItems
    {
        public override string Index(params object[] searchKey)
        {
            string timeZone = string.Empty;
            DateTime timeInterval = DateTime.Parse(searchKey[0] as string);

            if (timeInterval.Hour >= 8 && timeInterval.Hour <= 18) timeZone = TimeZone.OnPeak.ToString();
            else timeZone = TimeZone.OffPeak.ToString();

            return timeZone;
        }
    }
}
