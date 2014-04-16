using System;

class Problem4WeAllLoveBits
{
    static void Main()
    {
        int N;
        string numberString,numReverse = String.Empty;

        N = int.Parse(Console.ReadLine());
        int[] number = new int[N];

        for (int i = 0; i < N; i++)
        {
            number[i] = int.Parse(Console.ReadLine());
            //number[i] ^= ~number[i];      //P ^ ~P = 0xffff
		    numberString = Convert.ToString(number[i], 2);
		    char[] cNumArray = numberString.ToCharArray();
		    for (int j = cNumArray.Length - 1; j > -1; j--) numReverse += cNumArray[j];
		    numberString = numReverse;
		    number[i] = Convert.ToInt32(numberString,2);
		    numReverse = String.Empty;
        }

        for (int i = 0; i < N; i++) Console.WriteLine(number[i]);
    }
}

