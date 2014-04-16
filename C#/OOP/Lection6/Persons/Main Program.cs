using System;
using System.Linq;

namespace Persons
{
    class Program
    {
        static void Main()
        {
            Person ivan = new Person("Ivan Petrov Dimitrov");
            Person pesho = new Person("Pesho Petrov Ivanov", 12);

            Console.WriteLine(ivan.ToString());
            Console.WriteLine(pesho.ToString());
        }
    }
}
