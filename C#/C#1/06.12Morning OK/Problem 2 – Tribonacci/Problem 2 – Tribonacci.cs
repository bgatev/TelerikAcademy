using System;
using System.Numerics;

class Problem2Tribonacci
{
    static void Main()
    {
        BigInteger t1, t2, t3, tSum,N;

        t1 = int.Parse(Console.ReadLine());
        t2 = int.Parse(Console.ReadLine());
        t3 = int.Parse(Console.ReadLine());
        N = int.Parse(Console.ReadLine());

        if (N == 1) tSum = t1;
        else if (N == 2) tSum = t2;
        else if (N == 3) tSum = t3;
        else tSum = t1+t2+t3;

            for (int i = 0; i < N-4; i++)
            {
                t1 = t2;
                t2 = t3;
                t3 = tSum;
                tSum = t1+t2+t3;
               
            }
            Console.WriteLine(tSum);
    }
}
