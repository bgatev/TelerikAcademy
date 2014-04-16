using System;
using System.Linq;

namespace Animals
{
    public class Dogs : Animal, ISound
    {
        public Dogs(int animalAge, string animalName, char animalSex) : base(animalAge, animalName, animalSex)
        {
        }
        
        public void Sound()
        {
            Console.WriteLine("Bau Bau");
        }
    }
}
