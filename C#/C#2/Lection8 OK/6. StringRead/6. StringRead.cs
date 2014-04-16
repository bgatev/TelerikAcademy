//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the 
//characters should be filled with '*'. Print the result string into the console.

using System;
using System.Linq;

class StringRead
{
    static void Main(string[] args)
    {
        string input = string.Empty;

        do
        {
            Console.Write("Input string less than 21 characters: ");
            input = Console.ReadLine();
        }
        while (input.Length > 20);

        input = input.PadRight(20, '*');
        Console.WriteLine(input);

    }
}

