namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Computer : ICommands
    {
        private readonly Battery battery;

        public Computer(ComputerType type, ICPU cpu, IRAM ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard, Battery battery)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            if (type != ComputerType.LAPTOP && type != ComputerType.PC)
            {
                this.VideoCard.IsMonochrome = true;
            }

            this.battery = battery;
            this.MotherBoard = new Motherboard(ram, videoCard);
        }

        public IMotherboard MotherBoard { get; set; }

        public IEnumerable<HardDrive> HardDrives { get; set; }

        public VideoCard VideoCard { get; set; }

        public ICPU Cpu { get; set; }

        public IRAM Ram { get; set; }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.MotherBoard.DrawOnVideoCard(string.Format("Battery status: {0}", this.battery.Percentage));
        }

        public void Play(int guessNumber)
        {
            int randomNumber = this.Cpu.GetRandomNumber(1, 10);
            this.MotherBoard.SaveRamValue(randomNumber);

            var number = this.MotherBoard.LoadRamValue();

            if (number + 1 != guessNumber + 1)
            {
                this.MotherBoard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.MotherBoard.DrawOnVideoCard("You win!");
            }
        }
     
        public void Process(int data)
        {
            this.MotherBoard.SaveRamValue(data);
            this.Cpu.SquareNumber(this.MotherBoard);
        }
    }
}
