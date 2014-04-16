using System;
using System.Numerics;

class Task5SubsetSums
{
    static void Main()
    {
        double S, numSum=0;
        double result=0;
        int N;

        S = double.Parse(Console.ReadLine());
        N = int.Parse(Console.ReadLine());

        double[] numbers = new double[N];

        for (int i = 0; i < N; i++) numbers[i] = double.Parse(Console.ReadLine());
       
        for (int i = 1; i < (1 << N); i++) //loop till 2^N
        {
            for (int j = 0; j < N; j++) if (((i & (1 << j)) >> j) == 1) numSum += numbers[j];       //if bit j=1
            if (numSum == S) result++;
            numSum = 0;
        }
        
        Console.WriteLine(result);

    }
}

