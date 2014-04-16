//Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. 
//Example:	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class CombinationKN
{
    static IEnumerable Combinations<T>(IEnumerable<T> elements, int k)
    {
        T[] elem = elements.ToArray();
        int size = elem.Length;

        if (k <= size)
        {
            int[] numbers = new int[k];
            for (int i = 0; i < k; i++) numbers[i] = i;
            
            do
            {
                yield return numbers.Select(n => elem[n]);
            }
            while (nextCombination(numbers, size, k));
        }
    }

    static bool nextCombination(int[] inArray, int n, int k)
    {
        bool finished = false, changed = false;

        if (k > 0)
        {
            for (int i = k - 1; !finished && !changed; i--)
            {
                if (inArray[i] < (n - 1) - (k - 1) + i)
                {
                    inArray[i]++;
                    if (i < k - 1) for (int j = i + 1; j < k; j++) inArray[j] = inArray[j - 1] + 1;
                    changed = true;
                }
                
                if (i == 0) finished = true;
                else finished = false;
            }
        }

        return changed;
    }
    
    static void Main()
    {
        int N, K, combinationCounter = 0;

        do
        {
            Console.WriteLine("Input N and K, where N > K:");
            N = int.Parse(Console.ReadLine());
            K = int.Parse(Console.ReadLine());
        }
        while (N < K);

        string[] numArray = new string[N];
        for (int i = 0; i < N; i++) numArray[i] = Convert.ToString(i + 1);
                
        foreach (IEnumerable<string> i in Combinations(numArray, K))
        {
            Console.WriteLine(string.Join(",", i));
            combinationCounter++;       // n! / ( k! * (n – k)! )
        }
        Console.WriteLine(combinationCounter);
    }
}

