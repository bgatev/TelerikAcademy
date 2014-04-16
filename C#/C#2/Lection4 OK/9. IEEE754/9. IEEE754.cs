//Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float). 
//Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
using System;
using System.Text;

class IEEE754
{
    static string HexToBinary(string inString)
    {
        string result = string.Empty;

        for (int i = 0; i < inString.Length; i++)
        {
            switch (inString[i].ToString())
            {
                case "0": result += "0000"; break;
                case "1": result += "0001"; break;
                case "2": result += "0010"; break;
                case "3": result += "0011"; break;
                case "4": result += "0100"; break;
                case "5": result += "0101"; break;
                case "6": result += "0110"; break;
                case "7": result += "0111"; break;
                case "8": result += "1000"; break;
                case "9": result += "1001"; break;
                case "A": result += "1010"; break;
                case "B": result += "1011"; break;
                case "C": result += "1100"; break;
                case "D": result += "1101"; break;
                case "E": result += "1110"; break;
                case "F": result += "1111"; break;
                default: result += ""; break;
            }
        }
        return result;
    }
    
    static void Main()
    {
        float num;
        string result = string.Empty;
        byte[] raw;
        StringBuilder sb = new StringBuilder(32);

        Console.WriteLine("Enter a single-precision floating-point number: ");
        num = float.Parse(Console.ReadLine());
        
        raw = BitConverter.GetBytes(num);
        Array.Reverse(raw);
        result = BitConverter.ToString(raw);
        
        foreach (char c in result)
        {
            sb.Append(HexToBinary(c.ToString()));
        }
        result = sb.ToString();
        
        Console.WriteLine("The Sign is: {0}", result[0]);
        Console.WriteLine("The Exponent is: {0}", result.Substring(1, 8));
        Console.WriteLine("The Mantissa is: {0}", result.Substring(9));
    }
}