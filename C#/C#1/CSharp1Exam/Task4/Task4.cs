using System;

class Fire
{
    static void Main()
    {
        int N;

        N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N/4*3; i++)
        {
            if ((2 * i) == N) break;
            for (int j = 0; j < N/2-1-i; j++) Console.Write('.');
            Console.Write('#');
            for (int j = 0; j < 2*i; j++) Console.Write('.');
            Console.Write('#');
            for (int j = 0; j < N/2-1-i; j++) Console.Write('.');
            Console.WriteLine();
        }

        for (int i = 0; i < N/4; i++)
        {
            for (int j = 0; j < i; j++) Console.Write('.');
            Console.Write('#');
            for (int j = 0; j < N-2-2*i; j++) Console.Write('.');
            Console.Write('#');
            for (int j = 0; j < i; j++) Console.Write('.');
            Console.WriteLine();
        }
        
        for (int i = 0; i < N; i++) Console.Write('-');
        Console.WriteLine();
        for (int i = 0; i < N / 2; i++)
        {
            for (int j = 0; j < i; j++) Console.Write('.');
            for (int j = 0; j < N/2-i; j++) Console.Write('\\');
            for (int j = 0; j < N/2-i; j++) Console.Write('/');
            for (int j = 0; j < i; j++) Console.Write('.');
            Console.WriteLine();
        }

    }
}