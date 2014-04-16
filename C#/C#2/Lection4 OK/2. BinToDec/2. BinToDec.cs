//Write a program to convert binary numbers to their decimal representation.

using System;

class BinToDec1
{
    static int BinToDec(string inString)
    {
        int result = 0;

        for (int i = inString.Length - 1, j = 0; i > -1 ; i--, j++) result += ((inString[i] - '0') * (int)Math.Pow(2, j)); 
        
        return result;
    }

    static string BinaryInvert(string inString)
    {
        string result = string.Empty;

        for (int i = 0; i < inString.Length; i++)
        {
            if (inString[i] == '0') result += 1;
            else result += 0;
        }

        return result;
    }

    static void Main()
    {
        string num = string.Empty;
        int decValue = 0, sign = 1;

        do
        {
            Console.Write("Input less or equal than 32-bit binary number:");
            num = Console.ReadLine();
        }
        while (num.Length > 32);
       

        if (num.Length < 32) decValue = BinToDec(num);
        else
        {
            if (num[0] == '1') sign = -1;       //get num sign
            num = num.Substring(1);             //get num without sign
            
            num = BinaryInvert(num);            //invert to get positive num
            decValue = BinToDec(num) + 1;
        }
        
        Console.WriteLine(sign*decValue);
    }
}

