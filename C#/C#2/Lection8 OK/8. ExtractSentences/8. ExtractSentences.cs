//Write a program that extracts from a given text all sentences containing given word.
//		Example: The word is "in". The text is:
//We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. 
//We will move out of it in 5 days.
//The expected result is:
//We are living in a yellow submarine.
//We will move out of it in 5 days.
//Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;
using System.Linq;

class ExtractSentences
{
    static string FindWord(string sentence, string wordToFind)
    {
        int startIndex = 0;

        do
        {
            startIndex = sentence.IndexOf(wordToFind);
            if (startIndex == -1) return "-1";

            if ((!char.IsLetterOrDigit(sentence, startIndex - 1)) && (!char.IsLetterOrDigit(sentence, startIndex + wordToFind.Length))) return wordToFind;
            
            sentence = sentence.Substring(startIndex + 1);
        }
        while (startIndex != -1);
        
        return "-1";
    }
    
    static void Main()
    {
        string inputText = string.Empty, searchWord = string.Empty;

        inputText = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        searchWord = Console.ReadLine();

        string[] sentences = inputText.Split('.');

        for (int i = 0; i < sentences.Length; i++)
        {
            sentences[i] = sentences[i].TrimStart(' ');
            if (searchWord == FindWord(sentences[i], searchWord)) Console.WriteLine(sentences[i] + '.');   
        }
    }
}

