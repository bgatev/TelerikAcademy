//Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

class HexToBin1
{
    static string HexToBin(string inString)
    {
        string result = string.Empty;

        for (int i = 0; i < inString.Length; i++)
        {
            switch (inString[i])
            {
                case '1': result += "0001"; break;
                case '2': result += "0010"; break;
                case '3': result += "0011"; break;
                case '4': result += "0100"; break;
                case '5': result += "0101"; break;
                case '6': result += "0110"; break;
                case '7': result += "0111"; break;
                case '8': result += "1000"; break;
                case '9': result += "1001"; break;
                case 'A': result += "1010"; break;
                case 'B': result += "1011"; break;
                case 'C': result += "1100"; break;
                case 'D': result += "1101"; break;
                case 'E': result += "1110"; break;
                case 'F': result += "1111"; break;
                case 'a': result += "1010"; break;
                case 'b': result += "1011"; break;
                case 'c': result += "1100"; break;
                case 'd': result += "1101"; break;
                case 'e': result += "1110"; break;
                case 'f': result += "1111"; break;
            }
            result += " ";
        }

        return result;
    }

    static void Main()
    {
        string num = string.Empty, binValue = string.Empty;
        
        do
        {
            Console.Write("Input less or equal than 8 bytes hex number:");
            num = Console.ReadLine();
        }
        while (num.Length > 8);

        binValue = HexToBin(num);
        Console.WriteLine(binValue);
    }
}

