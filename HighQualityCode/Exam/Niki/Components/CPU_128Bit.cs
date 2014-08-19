namespace Computers
{
    public class CPU_128Bit : CPU, ICPU
    {
        public CPU_128Bit(byte numberOfCores, byte numberOfBits) : base(numberOfCores, numberOfBits)
        {
        }

        public override void SquareNumber(IMotherboard motherBoard)
        {
            var data = motherBoard.LoadRamValue();

            if (data < 0)
            {
                motherBoard.DrawOnVideoCard("Number too low.");
            }
            else if (data > 2000)
            {
                motherBoard.DrawOnVideoCard("Number too high.");
            }
            else
            {
                int value = 0;

                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                motherBoard.DrawOnVideoCard(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        public new void GetRandomNumber(int min, int max)
        {
            base.GetRandomNumber(min, max);
        }
    }
}
