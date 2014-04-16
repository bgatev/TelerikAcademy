using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

class Problem5BracketsByAuthor
{
    static void Main()
    {
        string line = Console.ReadLine();
        int N = line.Length;
        
        BigInteger[,] matrix = new BigInteger[N + 1, N + 2];
        matrix[0, 0] = 1;

        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 1; i <= N; i++)
        {
            if (line[i - 1] == '(') matrix[i, 0] = 0;
            else matrix[i, 0] = matrix[i - 1, 1];
            
            for (int j = 1; j <= N; j++)
            {
                if (line[i - 1] == '(') matrix[i, j] = matrix[i - 1, j - 1];
                else if (line[i - 1] == ')') matrix[i, j] = matrix[i - 1, j + 1];
                else matrix[i, j] = matrix[i - 1, j - 1] + matrix[i - 1, j + 1];
            }
        }
        sw.Stop();
        //Console.WriteLine(sw.Elapsed);
        Console.WriteLine(matrix[N, 0]);
    }
}

