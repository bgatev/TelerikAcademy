using System;
using System.Linq;
using System.Numerics;

class GagNumbers
{
    static void Main()
    {
        string[] alphabet = new string[9] { "-!","**","!!!","&&","&-","!-","*!!!","&*!","!!**!-" };
        BigInteger result = 0;
        string inputStr = string.Empty;
           
        inputStr = Console.ReadLine();

        do
        {
            for (int i = 0; i < alphabet.Length; i++)
			{
                if (inputStr.StartsWith(alphabet[i]))
                {
                    result = result * 9 + i;
                    inputStr = inputStr.Remove(0, alphabet[i].Length);
                }
            }
        }
        while (inputStr.Length > 0);

        Console.WriteLine(result);
    }
}

