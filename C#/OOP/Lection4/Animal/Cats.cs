using System;
using System.Linq;

namespace Animals
{
    public class Cats : Animal
    {
        public Cats(int animalAge, string animalName, char animalSex):base(animalAge, animalName, animalSex)
        {
        }

        public virtual void Sound()
        {
            Console.WriteLine("Miyau");
        }
    }
}
