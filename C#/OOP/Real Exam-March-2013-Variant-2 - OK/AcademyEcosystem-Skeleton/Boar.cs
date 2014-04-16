using System;
using System.Linq;

namespace AcademyEcosystem
{
    public class Boar:Animal,ICarnivore,IHerbivore
    {
        private const int boarSize = 4;
        private int biteSize;

        public Boar(string name, Point location)
            : base(name, location, boarSize)
        {
            this.biteSize = 2;   
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null) return 0;
            else if (animal.Size <= this.Size) return animal.GetMeatFromKillQuantity();
            else return 0;
        }

        public int EatPlant(Plant plant)
        {
            if (plant == null) return 0;
            else 
            {
                this.Size++;
                return plant.GetEatenQuantity(this.biteSize);
            }
        }
    }
}
