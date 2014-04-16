//A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word and 
//translates it by using the dictionary. Sample dictionary:
//.NET – platform for applications from Microsoft
//CLR – managed execution environment for .NET
//namespace – hierarchical organization of classes

using System;
using System.Linq;

class Dictionary
{
    static string FindWord(string dictionaryLine, string wordToFind)
    {
        int startIndex = 0;
        string word = string.Empty;
        
        startIndex = dictionaryLine.IndexOf(wordToFind + " - ");

        if (startIndex != -1) word = dictionaryLine.Substring(startIndex + wordToFind.Length + 3);
        else return "-1";

        return word;
    }

    static void Main()
    {
        string[] dictionary = { ".NET - platform for applications from Microsoft", 
                                "CLR - managed execution environment for .NET",
                                "namespace - hierarchical organization of classes",
                                "CLR - no sense"};

        string searchWord = string.Empty, result = string.Empty;

        searchWord = Console.ReadLine();

        for (int i = 0; i < dictionary.Length; i++)
        {
            result = FindWord(dictionary[i], searchWord);
            if (result != "-1") break;
        }

        if (result == "-1") Console.WriteLine("There is no such word in the dictionary");
        else Console.WriteLine("That means: {0}", result);
    }
}

