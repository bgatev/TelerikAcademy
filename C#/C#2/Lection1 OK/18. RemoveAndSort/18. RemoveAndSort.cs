//* Write a program that reads an array of integers and removes from it a minimal number of elements in such way that the 
//remaining array is sorted in increasing order. Print the remaining sorted array. 
//Example:	{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}

using System;

class RemoveAndSort
{
    static void FindSequence(int[] inArray, string[] outArray, long numberOfCombinations)
    {
        for (int i = 1; i < numberOfCombinations; i++)
        {
            for (int j = 0; j < inArray.Length; j++)
            {
                if ((((1 << j) & i) >> j) == 1) outArray[i] += inArray[j];
            }            
        }
    }

    static bool isSorted(string inString)
    {
        int counter = 1;

        if (inString.Length == 1) return true;

        for (int i = 0; i < inString.Length - 1; i++)
        {
            if (inString[i] <= inString[i + 1]) counter++;
            if (counter == inString.Length) return true;
        }

        return false;
    }

    static string LongestSequence(string[] inArray, long numberOfCombinations)
    {
        int maxLenght = 1, index = 0;

        for (int i = 0; i < numberOfCombinations - 1; i++)
        {
            if (inArray[i] == null) break;
            if (inArray[i].Length > maxLenght) 
            {
                maxLenght = inArray[i].Length;
                index = i;
            }
        }

        return inArray[index];
    }
    

    static void Main()
    {
        int N;
        N = int.Parse(Console.ReadLine());

        int[] numArray = new int[N];
        for (int i = 0; i < N; i++) numArray[i] = int.Parse(Console.ReadLine());

        long numberOfCombinations = (long)Math.Pow(2, numArray.Length);
        string[] sequences = new string[numberOfCombinations];

        Console.WriteLine();
        
        FindSequence(numArray,sequences,numberOfCombinations);

        string[] tempSequences = new string[numberOfCombinations];

        for (int i = 1, j = 0; i < numberOfCombinations; i++)
        {
            if (isSorted(sequences[i]))
            {
                tempSequences[j] = sequences[i];
                j++;
                //Console.WriteLine(sequences[i]);
            }
        }

        Console.WriteLine(LongestSequence(tempSequences, numberOfCombinations));
       

    }
}

