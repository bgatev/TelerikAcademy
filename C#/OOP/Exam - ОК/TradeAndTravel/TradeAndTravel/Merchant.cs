using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Merchant:Shopkeeper,ITraveller
    {
        public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        public void TravelTo(Location location)
        {
            this.Location = location;
        }

        public override int CalculateSellingPrice(Item item)
        {
            if (item == null) return 0;
            else return item.Value;
        }

        public override int CalculateBuyingPrice(Item item)
        {
            if (item == null) return 0;
            else return item.Value / 2;
        }
    }
}
