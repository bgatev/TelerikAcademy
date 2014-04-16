using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Task2
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        List<string> words = new List<string>();
        
        for (int i = 0; i < N; i++) words.Add(Console.ReadLine());
        
        for (int i = 0; i < N; i++)
        {
            int index = words[i].Length % (N + 1);
            words.Insert(index, words[i]);
            
            if (index > i) words.RemoveAt(i);
            else words.RemoveAt(i+1);
        }

        char[,] printWord = new char[N,1001];
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < N; i++)
          for (int j = 0; j < words[i].Length; j++) printWord[i, j] = words[i][j];


        for (int j = 0; j < 1001; j++)
          for (int i = 0; i < N; i++) if (printWord[i, j] > 0) sb.Append(printWord[i, j]);

        Console.WriteLine(sb.ToString());
    }
}

class Task2Evening
{
    static string ReverseString(string s)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = s.Length - 1; i > -1; i--) sb.Append(s[i]);

        return sb.ToString();
    }
    
    static void Main1()
    {
        int longestWord = 0;    //optimization because of the last 20% - out of memory

        string line = Console.ReadLine();
        string[] word = line.Split(' ');

        for (int i = 0; i < word.Length; i++)
        {
            word[i] = ReverseString(word[i]);
            if (word[i].Length > longestWord) longestWord = word[i].Length;
        }

        char[,] printWord = new char[word.Length, longestWord];
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < word.Length; i++)
            for (int j = 0; j < word[i].Length; j++) printWord[i, j] = word[i][j];

        for (int j = 0; j < longestWord; j++)
            for (int i = 0; i < word.Length; i++) if (printWord[i, j] > 0) sb.Append(printWord[i, j]);

        for (int i = 0; i < sb.Length; i++)
        {
            int index = char.ToLower(sb[i]) - 'a' + 1;
            char symbol = sb[i];
            
            sb.Remove(i, 1);
            sb.Insert((index + i) % (sb.Length + 1), symbol);
        }

        Console.WriteLine(sb.ToString());
    }
}
