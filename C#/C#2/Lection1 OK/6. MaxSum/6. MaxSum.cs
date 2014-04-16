//Write a program that reads two integer numbers N and K and an array of N elements from the console. 
//Find in the array those K elements that have maximal sum.

using System;

class MaxSum
{
    static void Main()
    {
        int N, K, tempSum = 0, maxSum = 0, index = 0;

        N = int.Parse(Console.ReadLine());
        K = int.Parse(Console.ReadLine());

        int[] numArray = new int[N];
        for (int i = 0; i < numArray.Length; i++) numArray[i] = int.Parse(Console.ReadLine());

        for (int i = 0; i < numArray.Length-(K-1); i++)
        {
            for (int j = i; j < i+K; j++)
            {
                tempSum += numArray[j];    
            }
            if (tempSum > maxSum)
            {
                maxSum = tempSum;
                index = i;
            }
            tempSum = 0;
        }

        Console.Write("Max sum of {0} elements is {1}: ",K,maxSum);
        for (int i = index; i < index + K; i++) Console.Write("{0} ",numArray[i]);
    }
}
