using System;

class SevenlandNumbers
{
    static void Main()
    {
        int K, nextK, digit0, digit01;

        K = int.Parse(Console.ReadLine());
        
        if (K < 10) digit0 = K;
        else if (K < 100) digit0 = K % 10;
        else digit0 = (K % 100) % 10;

        digit01 = K % 100;

        if (K == 666) nextK = 1000;
        else if (digit01 == 66) nextK = K + 34;
        else if (digit0 == 6) nextK = K + 4;
        else nextK = K + 1;
      
        Console.WriteLine(nextK);

    }
}

