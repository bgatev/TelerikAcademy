using System;
using System.Linq;

namespace AcademyEcosystem
{
    public class Lion:Animal,ICarnivore
    {
        private const int lionSize = 6;

        public Lion(string name, Point location)
            : base(name, location, lionSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null) return 0;
            else if (animal.Size <= this.Size * 2)
            {
                this.Size++;
                return animal.GetMeatFromKillQuantity();
            }
            else return 0;
        }
    }
}
