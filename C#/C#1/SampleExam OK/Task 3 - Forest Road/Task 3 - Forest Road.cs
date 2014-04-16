using System;

class Task3ForestRoad
{
    static void Main()
    {
        int N;

        N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            for (int k = 0; k < i; k++) Console.Write('.');
            Console.Write('*');
            for (int j = 0; j < N - i - 1; j++) Console.Write('.');
            Console.WriteLine();
        }
        for (int i = 0; i < N-1; i++)
        {
            for (int k = 0; k < N - i - 2 ; k++) Console.Write('.');
            Console.Write('*');
            for (int j = 0; j < i + 1; j++) Console.Write('.');
            Console.WriteLine();
        }
    }
}
