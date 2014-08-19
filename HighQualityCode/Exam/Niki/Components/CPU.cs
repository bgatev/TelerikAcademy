namespace Computers
{
    using System;
    
    public class CPU
    {
        public static readonly Random Random = new Random();
        public readonly byte NumberOfBits;

        public CPU(byte numberOfCores, byte numberOfBits) 
        {
            this.NumberOfBits = numberOfBits;
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfCores { get; set; }

        public virtual void SquareNumber(IMotherboard motherBoard)
        {
        }

        public int GetRandomNumber(int min, int max)
        {
            int randomNumber;

            do
            {
                randomNumber = Random.Next(0, 1000);
            }
            while (!(randomNumber >= min && randomNumber <= max));

            return randomNumber;
        }
    }
}
