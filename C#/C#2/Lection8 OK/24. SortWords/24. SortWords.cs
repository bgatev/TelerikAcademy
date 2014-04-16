//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;
using System.Collections.Generic;
using System.Linq;

class SortWords
{
    static void Main()
    {
        string inputString = string.Empty;
        List<string> stringList = new List<string>();

        inputString = Console.ReadLine();

        string[] stringArray = inputString.Split(' ');

        for (int i = 0; i < stringArray.Length; i++) stringList.Add(stringArray[i]);

        stringList.Sort();

        foreach (var singleString in stringList)
        {
            Console.WriteLine(singleString);
        }
       
        
    }
}

