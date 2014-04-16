using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class CarrierType : RatingItems
    {
        public override string Index(params object[] searchKey)
        {
            string currentGPRSZone = string.Empty;

            foreach (var destination in searchKey)
            {
                switch (destination as string)
                {
                    case "2": currentGPRSZone = GPRSZone.Standard.ToString();
                        break;
                    case "3": currentGPRSZone = GPRSZone.HSPA.ToString();
                        break;
                    case "4": currentGPRSZone = GPRSZone.LTE.ToString();
                        break;
                    default: currentGPRSZone = GPRSZone.Normal.ToString();
                        break;
                }
            }

            return currentGPRSZone;
        }
    }
}
