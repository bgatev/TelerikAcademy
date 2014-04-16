using System;
using System.Linq;

namespace Animals
{
    public class TomCat:Cats, ISound
    {
        public TomCat(int animalAge, string animalName) : base(animalAge, animalName, 'M')
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Mrrrrrr");
        }
    }
}
