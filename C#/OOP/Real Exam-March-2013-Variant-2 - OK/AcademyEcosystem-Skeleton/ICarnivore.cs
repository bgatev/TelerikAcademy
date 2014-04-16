using System;
using System.Linq;

namespace AcademyEcosystem
{
    public interface ICarnivore
    {
        int TryEatAnimal(Animal animal);
    }
}
