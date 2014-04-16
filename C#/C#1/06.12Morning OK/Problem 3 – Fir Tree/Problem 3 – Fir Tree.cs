using System;

class Problem3FirTree
{
    static void Main()
    {
        int N, realN;

        N = int.Parse(Console.ReadLine());
        realN = N - 1;

        for (int i = 0; i < realN; i++)
        {
            for (int j = 0; j < (2*realN-1)/2-i; j++) Console.Write('.');
            for (int j = 0; j < 2*i+1; j++) Console.Write('*');
            for (int j = 0; j < (2*realN-1)/2-i; j++) Console.Write('.');
            Console.WriteLine();       
        }
        
        for (int j = 0; j < (2 * realN - 1) / 2; j++) Console.Write('.');
        Console.Write('*');
        for (int j = 0; j < (2 * realN - 1) / 2; j++) Console.Write('.');
        Console.WriteLine();
    }
}

