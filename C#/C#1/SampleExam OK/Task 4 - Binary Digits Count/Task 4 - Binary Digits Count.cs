using System;

class Task4BinaryDigitsCount
{
    static void Main()
    {
        uint B, N, headZero = 0;
	    
		B=uint.Parse(Console.ReadLine());
		N=uint.Parse(Console.ReadLine());

        uint[] number = new uint[N];
        uint[] count = new uint[N];

        for (int k = 0; k < N; k++) count[k] = 0;
       
		for(int i = 0; i < N; i++)
		{
			number[i]=uint.Parse(Console.ReadLine());
            for (int j = 0; j < 32; j++)
            {
                if ((number[i] & (1 << j)) != 0)
                {
                    count[i]++;
                    headZero = (uint)j;                 //Last bit, that is 1
                }
            }
            number[i] = headZero + 1 - count[i];        //number of Zeroes
		}

        if (B == 1) for (int k = 0; k < N; k++) Console.WriteLine(count[k]);
        else for (int k = 0; k < N; k++) Console.WriteLine(number[k]);
       
    }
}

