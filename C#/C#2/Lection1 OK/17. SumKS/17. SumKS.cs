//* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
//Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;

class SumKS
{
    static void SubsetSum(int[] inArray, int desiredSum, int lenghtOfSequence)
    {
        int tempSum = 0, numberOfSumS = 0;
        string tempSequence = string.Empty;

        long numberOfCombinations = (long)Math.Pow(2, inArray.Length);
        for (int i = 1; i < numberOfCombinations; i++)
        {
            for (int j = 0; j < inArray.Length; j++)
            {
                if ((((1 << j) & i) >> j) == 1) tempSum += inArray[j];
            }

            if (tempSum == desiredSum)
            {
                for (int j = 0; j < inArray.Length; j++)
                {
                    if ((((1 << j) & i) >> j) == 1) tempSequence += inArray[j];
                }
                if (tempSequence.Length == lenghtOfSequence)
                {
                    numberOfSumS++;
                    for (int j = 0; j < tempSequence.Length; j++) Console.Write("{0} ", tempSequence[j]);
                    Console.WriteLine();
                }           
                tempSequence = string.Empty;
            }
            tempSum = 0;
        }

        Console.WriteLine("You have {0} subsets that makes {1}", numberOfSumS, desiredSum);

    }

    static void Main()
    {
        int n, k, sumS;
        sumS = int.Parse(Console.ReadLine());
        k = int.Parse(Console.ReadLine());

        n = int.Parse(Console.ReadLine());
        
        int[] numArray = new int[n];
        for (int i = 0; i < numArray.Length; i++) numArray[i] = int.Parse(Console.ReadLine());

        SubsetSum(numArray, sumS, k);
        
    }
}
