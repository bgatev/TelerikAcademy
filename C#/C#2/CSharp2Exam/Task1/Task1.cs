using System;
using System.Linq;

class Task1
{
    static void Main()
    {
        string[] alphabet = new string[13] { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };

        long result = 0;
        string inputStr = string.Empty;

        inputStr = Console.ReadLine();

        do
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (inputStr.StartsWith(alphabet[i]))
                {
                    result = result * 13 + i;
                    inputStr = inputStr.Remove(0, alphabet[i].Length);
                }
            }
        }
        while (inputStr.Length > 0);

        Console.WriteLine(result);

    }
}

class Task1Evening
{
    static void Main1()
    {
        string[] alphabet = new string[15] { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };

        long result = 0;
        string inputStr = string.Empty;

        inputStr = Console.ReadLine();

        do
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (inputStr.StartsWith(alphabet[i]))
                {
                    result = result * 15 + i;
                    inputStr = inputStr.Remove(0, alphabet[i].Length);
                }
            }
        }
        while (inputStr.Length > 0);

        Console.WriteLine(result);

    }
}