using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class Destination : RatingItems
    {
        public Destination()
        {
        }

        public override string Index(params object[] searchKey)
        {
            string destinationZone = string.Empty;

            foreach (var destination in searchKey)
            {
                switch (destination as string)
                {
                    case "35987": destinationZone = DestZone.Vivacom.ToString();
                        break;
                    case "35988": destinationZone = DestZone.Mtel.ToString();
                        break;
                    case "35989": destinationZone = DestZone.Globul.ToString();
                        break;
                    default: destinationZone = DestZone.Others.ToString();
                        break;
                }
            }

            return destinationZone;
        }
    }
}
