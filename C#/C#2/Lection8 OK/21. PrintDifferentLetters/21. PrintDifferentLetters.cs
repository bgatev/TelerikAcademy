//Write a program that reads a string from the console and prints all different letters in the string along with information how many 
//times each letter is found. 

using System;
using System.Collections.Generic;
using System.Linq;

class PrintDifferentLetters
{
    static int CharCounter(string inString, char symbol)
    {
        int counter = 0;

        for (int i = 0; i < inString.Length; i++)
        {
            if (inString[i] == symbol) counter++;
        }

        return counter;
    }
    
    static void Main()
    {
        string inputString = string.Empty;
        List<char> charList = new List<char>();

        inputString = Console.ReadLine();
            
        for (int i = 0; i < inputString.Length; i++) charList.Add(inputString[i]);

        IEnumerable<char> distinctChars = charList.Distinct();

        foreach (char symbol in distinctChars)
        {
            Console.WriteLine("{0} - {1} times", symbol, CharCounter(inputString, symbol));
        }
    }
}

