using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    class MainProgram
    {
        static void Main()
        {
            List<Dogs> dogs = new List<Dogs>(){ new Dogs(1,"Dara",'F'),
                                                new Dogs(2,"Pesho",'M'),
                                                new Dogs(5,"Chakalita",'F'),};

            List<Frogs> frogs = new List<Frogs>(){  new Frogs(1,"Chochko"),
                                                    new Frogs(3,"Jabcho",'F'),
                                                    new Frogs(2,"Bochko",'M')};

            List<Cats> cats = new List<Cats>(){ new Kitten(2,"Kotio"),
                                                new Kitten(13,"Kotanka"),
                                                new Kitten(3,"Pisana"),
                                                new TomCat(6,"Miro"),
                                                new TomCat(4,"Simeon"),
                                                new TomCat(5,"Kancho")};
            dogs[0].Sound();
            frogs[0].Sound();
            cats[0].Sound();
            cats[5].Sound();

            List<Animal> zoo = new List<Animal>();
            zoo.AddRange(dogs);
            zoo.AddRange(frogs);
            zoo.AddRange(cats);

            Animal.AverageAge(zoo);
        }
    }
}
