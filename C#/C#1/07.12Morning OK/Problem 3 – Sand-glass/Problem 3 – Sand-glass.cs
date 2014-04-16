using System;

class Problem3Sandglass
{
    static void Main()
    {
        int N;

        N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N/2; i++)
        {
            for (int j = 0; j < i; j++) Console.Write('.');
            for (int k = 0; k < N-2*i; k++) Console.Write('*');
            for (int j = 0; j < i; j++) Console.Write('.');
            Console.WriteLine();
        }

        if ((N % 2) != 0)
        {
            for (int i = N / 2; i >= 0; i--)
            {
                for (int j = 0; j < i; j++) Console.Write('.');
                for (int k = 0; k < N - 2 * i; k++) Console.Write('*');
                for (int j = 0; j < i; j++) Console.Write('.');
                Console.WriteLine();
            }
        }
        else
        {
            for (int i = N / 2 - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++) Console.Write('.');
                for (int k = 0; k < N - 2 * i; k++) Console.Write('*');
                for (int j = 0; j < i; j++) Console.Write('.');
                Console.WriteLine();
            }
        }
    }
}

