using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    public class TimeInterval : RatingItems
    {
        public override string Index(params object[] searchKey)
        {
            string timeZone = string.Empty;

            foreach (var timeInterval in searchKey)
            {
                switch (timeInterval as string)
                {
                    case "OffPeak": timeZone = TimeZone.OffPeak.ToString();
                        break;
                    default: timeZone = TimeZone.OnPeak.ToString();
                        break;
                }
            }

            return timeZone;
        }
    }
}
