using System;
using System.Linq;

namespace AcademyEcosystem
{
    class Program
    {
        static Engine GetEngineInstance()
        {
            //return new Engine();
            return new ExtendedEngine();
        }

        static void Main(string[] args)
        {
            Engine engine = GetEngineInstance();

            string command = Console.ReadLine();
            while (command != "end")
            {
                engine.ExecuteCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}
