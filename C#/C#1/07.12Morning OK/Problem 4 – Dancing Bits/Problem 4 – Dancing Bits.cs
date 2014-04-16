using System;

class Problem4DancingBits
{
    static void Main()
    {
        int K, N, numRead, result=0, numSeq=0;
        string stringInput=String.Empty;

        K = int.Parse(Console.ReadLine());
        N = int.Parse(Console.ReadLine());


        for (int i = 0; i < N; i++)
        {
            numRead = int.Parse(Console.ReadLine());
            stringInput += Convert.ToString(numRead,2);
        }

        for (int i = 0; i < stringInput.Length - 1; i++)
        {
            if (stringInput[i] == stringInput[i + 1]) numSeq++;
            else
            {
                if (numSeq == K - 1) result++;
                numSeq = 0;
            }

           
        }

        if (numSeq == K - 1) result++;
        
        //Console.WriteLine(stringInput);
        
        Console.WriteLine(result);
    }
}

