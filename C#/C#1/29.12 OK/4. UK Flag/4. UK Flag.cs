using System;

class UKFlag
{
    static void Main()
    {
        int N;
        N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N / 2; i++)
        {
            for (int j = 0; j < i; j++) Console.Write('.');
            Console.Write('\\');
            for (int j = 0; j < N / 2 - 1 - i; j++) Console.Write('.');
            Console.Write('|');
            for (int j = 0; j < N / 2 - 1 - i; j++) Console.Write('.');
            Console.Write('/');
            for (int j = 0; j < i; j++) Console.Write('.');
            Console.WriteLine();
        }

        for (int j = 0; j < N / 2; j++) Console.Write('-');
        Console.Write('*');
        for (int j = 0; j < N / 2; j++) Console.Write('-');
        Console.WriteLine();

        for (int i = N / 2; i > 0; i--)
        {
            for (int j = 0; j < i - 1; j++) Console.Write('.');
            Console.Write('/');
            for (int j = 0; j < N / 2 - i; j++) Console.Write('.');
            Console.Write('|');
            for (int j = 0; j < N / 2 - i; j++) Console.Write('.');
            Console.Write('\\');
            for (int j = 0; j < i - 1; j++) Console.Write('.');
            Console.WriteLine();
        }

    }
}

