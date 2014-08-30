using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static List<int> FindLongestSubsequence(List<int> input)
    {
        List<int> result = new List<int>();
        int count = 1, maxCount = 0, element = 0;

        for (int i = 0; i < input.Count - 1; i++)
        {
            if (input[i] == input[i + 1]) count++;
            else if (count > maxCount)
            {
                maxCount = count;
                count = 1;
                if (i == 0) element = input[i];
                else element = input[i - 1];
            }

            if (i == input.Count - 2)
            {
                if (count > maxCount)
                {
                    maxCount = count;
                    count = 1;
                    element = input[i - 1];
                }
            }
        }

        for (int i = 0; i < maxCount; i++)
        {
            result.Add(element);
        }

        return result;
    }

    public static void Main()
    {
        List<int> allNumbers = new List<int>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == string.Empty) break;

            int num = int.Parse(input);
            allNumbers.Add(num);
        }

        List<int> longestSubsequence = FindLongestSubsequence(allNumbers);

        Console.WriteLine("Longest Subsequence is {0} numbers of {1}", longestSubsequence.Count, longestSubsequence[0]);
    }
}

