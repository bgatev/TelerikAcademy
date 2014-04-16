using System;

class Problem3Trapezoid
{
    static void Main()
    {
        int N;

        N = int.Parse(Console.ReadLine());
        
        for (int j = 0; j < N; j++) Console.Write('.');
        for (int k = 0; k < N; k++) Console.Write('*');
        Console.WriteLine();
        
        for (int i = 0; i < N-1; i++)
        {
            for (int j = 0; j < N-1-i; j++) Console.Write('.');
            Console.Write('*');
            for (int k = 0; k < N-1+i; k++) Console.Write('.');
            Console.Write('*');
            Console.WriteLine();
        }

        for (int i = 0; i < 2*N; i++) Console.Write('*');
        Console.WriteLine();
    }
}

