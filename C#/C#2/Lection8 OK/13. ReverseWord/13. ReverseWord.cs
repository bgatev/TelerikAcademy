//Write a program that reverses the words in given sentence.
//	Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Linq;

class ReverseWord
{
    static void Main()
    {
        string inputSentence = string.Empty, result = string.Empty;
        

        inputSentence = "C# is not C++, not PHP and not Delphi!";
        char lastChar = inputSentence[inputSentence.Length - 1];

        inputSentence = inputSentence.Substring(0, inputSentence.Length - 1);


        string[] words = inputSentence.Split(' ');
        for (int j = words.Length - 1; j > -1; j--) result += words[j] + ' ';       

        result = result.Substring(0, result.Length - 1) + lastChar;
        Console.WriteLine(result);
    }
}

