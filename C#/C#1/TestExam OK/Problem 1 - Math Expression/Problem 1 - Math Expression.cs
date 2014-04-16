using System;
using System.Threading;
using System.Globalization;

class Problem1MathExpression
{
    static void Main()
    {
        double N, M, P, result;

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        N = double.Parse(Console.ReadLine());
        M = double.Parse(Console.ReadLine());
        P = double.Parse(Console.ReadLine());
        
        result = (N * N + 1 / (M * P) + 1337) / (N - 128.523123123 * P) + Math.Sin((int)(M % 180));
        
        Console.WriteLine("{0:0.000000}",result);

    }
}

