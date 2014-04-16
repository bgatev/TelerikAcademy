using System;

class Sheets
{
    static void Main()
    {
        int N;
        N = int.Parse(Console.ReadLine());

        for (int i = 0; i < 11; i++) if ((N & (1 << i)) == 0) Console.WriteLine("A{0}", 10 - i);
    }
}

