//* Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
//Example:	n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

using System;

class PermutationN
{
    static void SwapElementsInArray(int[] inArray, int sourceElement, int destElement)
    {
        int temp = 0;

        temp = inArray[sourceElement];
        inArray[sourceElement] = inArray[destElement];
        inArray[destElement] = temp;
    }
    
    static bool PermN(int[] inArray, int sequenceLength)        //SEPA Algorithm
    {
        int num = sequenceLength - 1;
        int newNum = sequenceLength - 1;

        while ( (num > 0) && (inArray[num] <= inArray[num - 1]) ) num--;
        
        num--;

        if (num < 0) return false;

        newNum = sequenceLength - 1;
        while ( (newNum > num) && (inArray[newNum] <= inArray[num]) ) newNum--;

        SwapElementsInArray(inArray, num, newNum);

        sequenceLength--;
        num++;

        while (sequenceLength > num)
        {
            SwapElementsInArray(inArray, sequenceLength, num);
            num++;
            sequenceLength--;
        }

        return true;
     }
    
    static void Main()
    {
        int N, permCounter = 0;
        N = int.Parse(Console.ReadLine());

        int[] numArray = new int[N];
        for (int i = 0; i < N; i++) numArray[i] = i;

        do
        {
            for (int i = 0; i < N; i++) Console.Write("{0} ",numArray[i]);
            Console.WriteLine();
            permCounter++;                  // n!
        }
        while (PermN(numArray, N));
        Console.WriteLine(permCounter);
    }
}

