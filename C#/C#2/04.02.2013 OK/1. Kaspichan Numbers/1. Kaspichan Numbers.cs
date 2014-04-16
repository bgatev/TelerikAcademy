using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

class Kaspichan_Numbers
{ 
    static void Main()
    {
        string[] alphabet = new string[256];
        int counter = 0;
        BigInteger inputNum = 0;
        
        List<string> resultNum = new List<string>();

        for (char i = 'A'; i <= 'Z'; i++) alphabet[counter++] = i.ToString();
        for (char i = 'a'; i < 'j'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                if (counter > 255) continue;
                alphabet[counter++] = i.ToString() + j.ToString();      
            }
        }

        inputNum = BigInteger.Parse(Console.ReadLine());

        do
        {
            resultNum.Add(alphabet[(int)(inputNum % 256)]);
            inputNum /= 256;
        }
        while (inputNum > 0);
   
        resultNum.Reverse();

        foreach (var item in resultNum)
        {
            Console.Write(item);
        }

        Console.WriteLine();
    }
}

