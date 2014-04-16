using System;
using System.Linq;

namespace AcademyEcosystem
{
    public class Wolf:Animal,ICarnivore
    {
        private const int wolfSize = 4;

        public Wolf(string name, Point location)
            : base(name, location, wolfSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null) return 0;
            else if (animal.Size <= this.Size || animal.State == AnimalState.Sleeping) return animal.GetMeatFromKillQuantity();
            else return 0;
        }
    }
}
