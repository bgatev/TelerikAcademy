//Write a program that finds in given array of integers a sequence of given sum S (if present). 
//Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}

using System;

class SequenceSum1
{
    static void SequenceSum(int[] inArray, int desiredSum)
    {
        int tempsum = 0;
        string numSequence = string.Empty;

        for (int i = 0, j = 0; i < inArray.Length; i++)
        {
            for (j = i; j < inArray.Length; j++)
            {
                tempsum += inArray[j];
                numSequence += Convert.ToString(inArray[j]) + " ";
                if (tempsum >= desiredSum) break;
            }
            if (tempsum == desiredSum)
            {
                Console.WriteLine("You have sum {0} from these numbers: {1}",desiredSum, numSequence);
                break;
            }
            tempsum = 0;
            numSequence = string.Empty;
        }
    }

    static void SubsetSum(int[] inArray, int desiredSum)
    {
        int tempSum = 0, numberOfSumS = 0;

        long numberOfCombinations = (long)Math.Pow(2, inArray.Length);
        for (int i = 1; i < numberOfCombinations; i++)
        {
            for (int j = 0; j < inArray.Length; j++)
            {
                if ((((1 << j) & i) >> j) == 1) tempSum += inArray[j];
            }

            if (tempSum == desiredSum)
            {
                numberOfSumS++;
                for (int j = 0; j < inArray.Length; j++)
                {
                    if ((((1 << j) & i) >> j) == 1) Console.Write("{0} ", inArray[j]);
                }
                Console.WriteLine();
            }
            tempSum = 0;
        }

        Console.WriteLine("You have {0} subsets that makes {1}", numberOfSumS, desiredSum);

    }

    static void Main()
    {
        int n, sumS;
        sumS = int.Parse(Console.ReadLine());

        n = int.Parse(Console.ReadLine());
        
        int[] numArray = new int[n];
        for (int i = 0; i < numArray.Length; i++) numArray[i] = int.Parse(Console.ReadLine());

        SequenceSum(numArray, sumS);
        SubsetSum(numArray, sumS);
        
    }
}

