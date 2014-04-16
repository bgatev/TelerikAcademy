using System;
using System.Numerics;

class QuadronacciRectangle
{
    static void Main()
    {
        BigInteger q1, q2, q3, q4, R, C, qSum;

        q1 = int.Parse(Console.ReadLine());
        q2 = int.Parse(Console.ReadLine());
        q3 = int.Parse(Console.ReadLine());
        q4 = int.Parse(Console.ReadLine());
        R = int.Parse(Console.ReadLine());
        C = int.Parse(Console.ReadLine());

        qSum = q1 + q2 + q3 + q4;

        Console.Write("{0} {1} {2} {3} ", q1, q2, q3, q4);

        for (int i = 0; i < R; i++)
        {
            for (int j = 0; j < C; j++)
            {
                if ((i == 0) & (j == 0)) j = 4;
                if ((i == 0) & (C == 4))
                {
                    
                }
                else
                {    
                    Console.Write("{0} ", qSum);
                    q1 = q2;
                    q2 = q3;
                    q3 = q4;
                    q4 = qSum;
                    qSum = q1 + q2 + q3 + q4;
                }

            }
            Console.WriteLine();
        }
    }
}

