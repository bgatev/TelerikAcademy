namespace Computers
{
    using System;
    using System.Collections.Generic;

    public class Computers
    {
        public static void Main()
        {
            Computer pc, server, laptop;

            var manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                var HPPC = new HPPersonalComputer();
                var HPPCRam = new RAM(2);
                var HPPCVideoCard = new VideoCard() { IsMonochrome = false };

                pc = new Computer(ComputerType.PC, HPPC.GetCPU(), HPPCRam, new[] { new HardDrive(500, false, 0) }, HPPCVideoCard, null);

                var HPServer = new HPServer();
                var HPServerRam = new RAM(32);
                var HPServerVideoCard = new VideoCard();

                server = new Computer(
                    ComputerType.SERVER, 
                    HPServer.GetCPU(), 
                    HPServerRam, 
                    new List<HardDrive>
                        { 
                            new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(1000, false, 0), new HardDrive(1000, false, 0) })
                        },
                    HPServerVideoCard, 
                    null);

                var HPLaptop = new HPLaptop();
                var HPLaptopRam = new RAM(4);
                var HPLaptopVideoCard = new VideoCard() { IsMonochrome = false };

                laptop = new Computer(ComputerType.LAPTOP, HPLaptop.GetCPU(), HPLaptopRam, new[] { new HardDrive(500, false, 0) }, HPLaptopVideoCard, new Battery());
            }
            else if (manufacturer == "Dell")
            {
                var DellPC = new DellPersonalComputer();
                var DellPCRam = new RAM(8);
                var DellPCVideoCard = new VideoCard() { IsMonochrome = false };

                pc = new Computer(ComputerType.PC, DellPC.GetCPU(), DellPCRam, new[] { new HardDrive(1000, false, 0) }, DellPCVideoCard, null);

                var DellServer = new DellServer();
                var DellServerRam = new RAM(64);
                var DellServerVideoCard = new VideoCard();

                server = new Computer(
                    ComputerType.SERVER, 
                    DellServer.GetCPU(), 
                    DellServerRam, 
                    new List<HardDrive>
                        {
                            new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(2000, false, 0), new HardDrive(2000, false, 0) })
                        },
                     DellServerVideoCard, 
                     null);

                var DellLaptop = new DellLaptop();
                var DellLaptopRam = new RAM(8); 
                var DellLaptopVideoCard = new VideoCard() { IsMonochrome = false };
                laptop = new Computer(ComputerType.LAPTOP, DellLaptop.GetCPU(), DellLaptopRam, new[] { new HardDrive(1000, false, 0) }, DellLaptopVideoCard, new Battery());
            }
            else if (manufacturer == "Lenovo")
            {
                var LenovoPC = new LenovoPersonalComputer();
                var LenovoPCRam = new RAM(4);
                var LenovoPCVideoCard = new VideoCard() { IsMonochrome = false };

                pc = new Computer(ComputerType.PC, LenovoPC.GetCPU(), LenovoPCRam, new[] { new HardDrive(2000, false, 0) }, LenovoPCVideoCard, null);

                var LenovoServer = new LenovoServer();
                var LenovoServerRam = new RAM(8);
                var LenovoServerVideoCard = new VideoCard();

                server = new Computer(
                    ComputerType.SERVER,
                    LenovoServer.GetCPU(),
                    LenovoServerRam,
                    new List<HardDrive>
                        { 
                            new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(500, false, 0), new HardDrive(500, false, 0) })
                        },
                    LenovoServerVideoCard,
                    null);

                var LenovoLaptop = new LenovoLaptop();
                var LenovoLaptopRam = new RAM(16);
                var LenovoLaptopVideoCard = new VideoCard();

                laptop = new Computer(ComputerType.LAPTOP, LenovoLaptop.GetCPU(), LenovoLaptopRam, new[] { new HardDrive(1000, false, 0) }, LenovoLaptopVideoCard, new Battery());
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            while (true)
            {
                var inputLine = Console.ReadLine();
                if ((inputLine == null) || inputLine.StartsWith("Exit"))
                {
                    break;
                }

                var currentCommand = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                ICommands command = CommandsSimpleFactory.GetCommand(currentCommand, pc, server, laptop);
            }
        }
    }
}
