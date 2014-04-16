//Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
//Example:	N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class VariationKN1
{
       
    static void VariationKN(int numN, int numK)
    {
        for (int i = 0; i < Math.Pow(numN, numK); i++)
        {
            int conv = i;
            int[] numArray = new int[numK];

            //convert from decimal to n-number system
            for (int j = 0; j < numK; j++)
            {
                numArray[numK - j - 1] = conv % numN;
                conv = conv / numN;
            }

            if (i == 0) Console.Write("{0}", numArray[0] + 1);
            else Console.Write("  {0}", numArray[0] + 1);

            for (uint j = 1; j < numK; j++) Console.Write(",{0}", numArray[j] + 1);
        }
    }

    static void Main()
    {
        int N, K;

        do
        {
            Console.WriteLine("Input N and K, where N > K:");
            N = int.Parse(Console.ReadLine());
            K = int.Parse(Console.ReadLine());
        }
        while (N < K);

        VariationKN(N, K);
    }
}

