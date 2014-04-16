//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Linq;

class ExtractPalindromes
{
    static bool CheckPalindrom(string word)
    {
        int counter = 0;

        for (int i = 0; i < word.Length / 2; i++) if ((word[i] == word[word.Length - i - 1]) && (char.IsLetterOrDigit(word, i))) counter++;
        
        if (counter == word.Length / 2) return true;
        else return false;
    }
    
    static void Main()
    {
        string inputText = string.Empty;

        inputText = "Write a program that extracts from a given text all 575 palindromes, e.g. ABBA ,, lamal, exe";

        string[] words = inputText.Split(' ');

        for (int i = 0; i < words.Length; i++) if (CheckPalindrom(words[i])) Console.WriteLine(words[i]);
    }
}

