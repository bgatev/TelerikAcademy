using System;

class Problem5FallDown
{
    static void Main()
    {
        int temp, temp1;
        int[] inputN = new int[8];
       
        for (int i = 0; i < 8; i++) inputN[i] = int.Parse(Console.ReadLine());

        for (int j = 0; j < 7; j++)
        {
            for (int i = 0; i < 7-j; i++)
            {
                temp1 = inputN[i] | inputN[i + 1];
                temp = inputN[i] & inputN[i + 1];
                inputN[i + 1] = temp1;
                inputN[i] = temp;
            }
        }

        for (int i = 0; i < 8; i++) Console.WriteLine(inputN[i]);
    }
}

