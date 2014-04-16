using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBilling
{
    public class RatingItemsCommon:RatingItems//, IRateable
    {
        public RatingItemsCommon(bool firstTimeInit = false, bool firstTimeInitGPRS = false)
        {
            if (firstTimeInit) RatingItems.CreateIndexTable();
            else if (firstTimeInitGPRS) RatingItems.CreateIndexTable(true);
        }
    }
}
