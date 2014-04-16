using System;
using System.Numerics;

class TribonacciTriangle
{
    static void Main()
    {
        BigInteger t1, t2, t3, tSum, L;

        t1 = int.Parse(Console.ReadLine());
        t2 = int.Parse(Console.ReadLine());
        t3 = int.Parse(Console.ReadLine());
        L = int.Parse(Console.ReadLine());

        tSum = t1 + t2 + t3;

        Console.WriteLine(t1);
        Console.WriteLine("{0} {1}",t2,t3);

        for (int i = 0; i < L - 2; i++)
        {
            for (int j = 0; j < i+3; j++)
            {

                Console.Write(tSum);
                Console.Write(" ");
                t1 = t2;
                t2 = t3;
                t3 = tSum;
                tSum = t1 + t2 + t3;
            }
            Console.WriteLine();
        }
    }
}

