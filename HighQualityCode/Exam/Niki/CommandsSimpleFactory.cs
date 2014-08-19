namespace Computers
{
    using System;
    using System.Linq;

    public class CommandsSimpleFactory
    {
        public static ICommands GetCommand(string[] command, Computer pc, Computer server, Computer laptop)
        {
            if (command.Length != 2)
            {
                throw new ArgumentException("Invalid command!");
            }

            var commandName = command[0];
            var commandArgument = int.Parse(command[1]);

            switch (commandName)
            {
                case "Charge": 
                    
                    laptop.ChargeBattery(commandArgument);
                    break;
                case "Process": server.Process(commandArgument);
                    break;
                case "Play": pc.Play(commandArgument);
                    break;
                default: new InvalidArgumentException("Invalid command!");
                    break;
            }

            return pc;
        }
    }
}
