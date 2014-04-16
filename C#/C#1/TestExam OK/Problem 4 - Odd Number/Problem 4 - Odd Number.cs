using System;
using System.Numerics;

class Problem4OddNumber
{
    static void Main()
    {
        /*BigInteger result=0;
        int N;

        N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            result ^= input;
        }

        Console.WriteLine(result);//	Advanced Solution*/
        
        decimal result=0;
        int N, count=0;

        N = int.Parse(Console.ReadLine());
        decimal[] number = new decimal[N];

        for (int i = 0; i < N; i++) number[i] = decimal.Parse(Console.ReadLine());
        
        for (int i = (N - 1); i >= 0; i--)
        {
            result = number[i];

            for (int j = 0; j < N; j++) if (result == number[j]) count++;
            if (count % 2 != 0) break;
            count = 0;
        }

        Console.WriteLine(result);
    }
}

