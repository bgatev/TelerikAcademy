//Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
//Hi!
//Expected output:
//\u0048\u0069\u0021

using System;
using System.Linq;

class StringToUnicode
{
    static void Main(string[] args)
    {
        string input = string.Empty, result = string.Empty;

        input = Console.ReadLine();

        //for (int i = 0; i < input.Length; i++) result += "\\u" + ((int)input[i]).ToString("X").PadLeft(4, '0'); 

        for (int i = 0; i < input.Length; i++) result += string.Format("\\u{0:X4}", (int)input[i]);     

        Console.WriteLine(result);
    }
}

