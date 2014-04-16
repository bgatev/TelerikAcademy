using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class DurankulakNumbers
{
    static void Main()
    {
        string[] alphabet = new string[168];
        int counter = 0;
        BigInteger result = 0;
        string inputStr = string.Empty;

        List<string> resultNum = new List<string>();

        for (char i = 'A'; i <= 'Z'; i++) alphabet[counter++] = i.ToString();
        for (char i = 'a'; i < 'j'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                if (counter > 167) continue;
                alphabet[counter++] = i.ToString() + j.ToString();
            }
        }

        inputStr = Console.ReadLine();

        for (int i = 0; i < inputStr.Length; i++)
        {
            int singleDigit = 0;

            if (char.IsUpper(inputStr[i])) singleDigit = inputStr[i] - 'A';
            else
            {
                singleDigit = (inputStr[i] - 'a' + 1) * 26 + inputStr[i + 1] - 'A';
                i++;
            }
            result = result * 168 + singleDigit;
        }

        Console.WriteLine(result);
    }
}

