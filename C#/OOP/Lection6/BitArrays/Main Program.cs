using System;
using System.Linq;

namespace BitArrays
{
    class Program
    {
        static void Main()
        {
            BitArray64 num = new BitArray64(147);
            
            Console.WriteLine(num.Bits[62]);

            try
            {
                Console.WriteLine(num.Bits[67]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            int[] bitArray = num.Bits;
            foreach (var number in bitArray)
            {
                Console.Write(number);
            }

            Console.WriteLine();
            Console.WriteLine(bitArray[59]);
        }
    }
}
