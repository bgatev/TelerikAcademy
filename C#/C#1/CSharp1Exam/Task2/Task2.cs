using System;

class DrunkenNumbers
{
    static void Main()
    {
        int N, vBeers = 0, mBeers = 0, noWinnerCase = 0; 
        int[] digits = new int[9];
        
        N = int.Parse(Console.ReadLine());
        long[] drunkNumbers = new long[N];

        for (int i = 0; i < N; i++) drunkNumbers[i] = long.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++) if (drunkNumbers[i] < 0) drunkNumbers[i] *= -1;

        for (int i = 0; i < N; i++)
		{
            int j = 0;
            while (drunkNumbers[i] > 0)
            {
	            digits[j] = (int)(drunkNumbers[i] % 10);
	            drunkNumbers[i] /= 10;
                j++;
            }

            for (int k = 0; k < j / 2; k++) vBeers += digits[k];
            for (int k = j / 2; k < j; k++) mBeers += digits[k];
            if ((j % 2) != 0)
            {
                vBeers += digits[j / 2];
                //noWinnerCase += digits[j / 2];
            }
            for (j = 0; j < 9; j++) digits[j] = 0;
        }
               
        if (vBeers > mBeers) Console.WriteLine("V {0}",vBeers - mBeers);
        else if (mBeers > vBeers) Console.WriteLine("M {0}", mBeers - vBeers);
        else Console.WriteLine("No {0}", mBeers + vBeers - noWinnerCase);
    }
}