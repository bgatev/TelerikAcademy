using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class Animal
    {
        private int age;
        private string name;
        private char sex;

        public Animal(int animalAge, string animalName) : this(animalAge,animalName,' ')
        {
        }

        public Animal(int animalAge, string animalName, char animalSex)
        {
            this.age = animalAge;
            this.name = animalName;
            this.sex = animalSex;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 0) this.age = value;
                else throw new ArgumentException("Invalid Age");
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length > 0) this.name = value;
                else throw new ArgumentException("Invalid Name");
            }
        }

        public char Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                if (value == ('M' | 'F')) this.sex = value;
                else throw new ArgumentException("Invalid Sex");
            }
        }

        public static void AverageAge(List<Animal> animals)
        {
            var groupedByType = animals.GroupBy(t => t.GetType());
            var groupedByTypeLinq = from a in animals
                                 let animalTypes = a.GetType()
                                 group a by animalTypes into animalGroups
                                 select animalGroups;

            foreach (var animal in groupedByType)
            {
                Console.WriteLine("Average age of {0} is {1} years", animal.Key.Name, animal.Average(a => a.Age)); 
            }

            foreach (var animal in groupedByTypeLinq)
            {
                Console.WriteLine("Linq Average age of {0} is {1} years", animal.Key.Name, animal.Average(a => a.Age));
            }
        }
    }
}
