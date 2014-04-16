using System;
using System.Linq;

namespace Animals
{
    public class Frogs : Animal, ISound
    {
        public Frogs(int animalAge, string animalName) : base(animalAge, animalName)
        {
        }
        
        public Frogs(int animalAge, string animalName, char animalSex) : base(animalAge, animalName, animalSex)
        {
        }

        public void Sound()
        {
            Console.WriteLine("Frog Frog");
        }
    }
}
