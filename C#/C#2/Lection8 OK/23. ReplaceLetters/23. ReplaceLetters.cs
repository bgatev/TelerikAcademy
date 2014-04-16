//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. 
//Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

using System;
using System.Linq;

class ReplaceLetters
{
    static void Main()
    {
        string inputString = string.Empty, result = string.Empty;

        inputString = Console.ReadLine();

        result += inputString[0];

        for (int i = 0; i < inputString.Length - 1; i++) if (inputString[i] != inputString[i + 1]) result += inputString[i + 1];
        
        Console.WriteLine(result);
    }
}

