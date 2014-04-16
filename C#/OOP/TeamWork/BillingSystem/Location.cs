using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class Location : RatingItems
    {
        public override string Index(params object[] searchKey)
        {
            string locationZone = string.Empty;

            foreach (var location in searchKey)
            {
                switch (location as string)
                {
                    case "BG": locationZone = LocZone.Home.ToString();
                        break;
                    case "BE":
                    case "CZ":
                    case "DK":
                    case "DE":
                    case "EE":
                    case "IE":
                    case "EL":
                    case "ES":
                    case "FR":
                    case "HR":
                    case "IT":
                    case "CY":
                    case "LV":
                    case "LT":
                    case "LU":
                    case "HU":
                    case "MT":
                    case "NL":
                    case "AT":
                    case "PL":
                    case "PT":
                    case "RO":
                    case "SI":
                    case "SK":
                    case "FI":
                    case "SE":
                    case "UK": locationZone = LocZone.EU.ToString();
                        break;
                    case "ME":
                    case "IS":
                    case "RS":
                    case "TR":
                    case "SW": locationZone = LocZone.NonEU.ToString();
                        break;
                    default: locationZone = LocZone.World.ToString();
                        break;
                }
            }

            return locationZone;
        }
    }
}
