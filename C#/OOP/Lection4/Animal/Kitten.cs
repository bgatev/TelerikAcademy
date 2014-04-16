using System;
using System.Linq;

namespace Animals
{
    public class Kitten: Cats, ISound
    {
        public Kitten(int animalAge, string animalName) : base(animalAge, animalName, 'F')
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Kiti Kiti Kiti");
        }
    }
}
