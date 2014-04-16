using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Rock:StaticObject,IResource
    {
        private int quantity;
        private ResourceType type;

        public Rock(int hitPoints, Point position):base(position,0)
        {
            this.HitPoints = hitPoints;
            this.type = ResourceType.Stone;
            this.quantity = this.HitPoints / 2;
        }

        public int Quantity
        {
            get { return this.quantity; }
        }
        
        public ResourceType Type
        {
            get { return this.type; }
        }
    }
}
