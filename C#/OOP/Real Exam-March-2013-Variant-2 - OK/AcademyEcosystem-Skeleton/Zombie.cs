using System;
using System.Linq;

namespace AcademyEcosystem
{
    public class Zombie:Animal
    {
        private const int zombieSize = 0;

        public Zombie(string name, Point location)
            : base(name, location, zombieSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            this.IsAlive = true;
            return 10;
        }
    }
}
