using System;
using System.Linq;

namespace AcademyEcosystem
{
    public class Grass:Plant
    {
        private const int grassSize = 2;

        public Grass(Point location)
            : base(location, grassSize)
        {
        }

        public override void Update(int time)
        {
            if (this.IsAlive) this.Size += time;
            base.Update(time);
        }
    }
}
