//Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

class BinToHex1
{
    static string BinToHex(string inString)
    {
        string result = string.Empty;

        for (int i = 0; i < inString.Length; i +=4)
        {
            string temp = string.Empty;
            temp = inString.Substring(i, 4);
            switch (temp)
            {
                case "0000": result += 0; break;
                case "0001": result += 1; break;
                case "0010": result += 2; break;
                case "0011": result += 3; break;
                case "0100": result += 4; break;
                case "0101": result += 5; break;
                case "0110": result += 6; break;
                case "0111": result += 7; break;
                case "1000": result += 8; break;
                case "1001": result += 9; break;
                case "1010": result += "A"; break;
                case "1011": result += "B"; break;
                case "1100": result += "C"; break;
                case "1101": result += "D"; break;
                case "1110": result += "E"; break;
                case "1111": result += "F"; break;
            }
        }
        result = result.TrimStart('0');     //remove leading zeros
        return result;
    }

    static void Main()
    {
        string num = string.Empty, hexValue = string.Empty;
        
        do
        {
            Console.Write("Input less or equal than 32-bit binary number:");
            num = Console.ReadLine();
        }
        while (num.Length > 32);

        num = num.PadLeft(32, '0');
        hexValue = BinToHex(num);
        
        Console.WriteLine(hexValue);
    }
}

