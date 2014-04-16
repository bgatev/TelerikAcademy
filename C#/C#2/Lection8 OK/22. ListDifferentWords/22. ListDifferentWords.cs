//Write a program that reads a string from the console and lists all different words in the string along with information how many times 
//each word is found.

using System;
using System.Collections.Generic;
using System.Linq;

class ListDifferentWords
{
    static int WordCounter(string[] inString, string word)
    {
        int counter = 0;

        for (int i = 0; i < inString.Length; i++)
        {
            if (inString[i] == word) counter++;
        }

        return counter;
    }

    static void Main()
    {
        string inputString = string.Empty;
        List<string> stringList = new List<string>();

        inputString = Console.ReadLine();
        string[] stringArray = inputString.Split(' ');

        for (int i = 0; i < stringArray.Length; i++) stringList.Add(stringArray[i]);

        IEnumerable<string> distinctString = stringList.Distinct();

        foreach (string word in distinctString)
        {
            Console.WriteLine("{0} - {1} times", word, WordCounter(stringArray, word));
        }
    }
}

