using System;

class NeuronMapping
{
    static void Main()
    {
        long numRead,exitCondition;
        int left=0, right=-1, counter=0;
        long[] result = new long[1000];

        do
        {
            numRead = long.Parse(Console.ReadLine());
            exitCondition = numRead;
            for (int i = 0; i < 31; i++)
            {
                if ((((numRead & (1 << i)) >> i) == 1) && (((numRead & (1 << (i + 1))) >> (i + 1)) == 0))
                {
                    right = i;
                    break;
                }
            }
            for (int i = 31; i > 0; i--)
            {
                if (i <= right) break;
                if ((((numRead & (1 << i)) >> i) == 1) && (((numRead & (1 << (i - 1))) >> (i - 1)) == 0))
                {
                    left = i;
                    break;
                }
            }
            if ((left > right) && (right != -1))
            {
                for (int i = 0; i < right + 1; i++) numRead &= ~(1 << i);
                for (int i = right + 1; i < left; i++) numRead |= (1 << i);
                for (int i = left; i < 32; i++) numRead &= ~(1 << i);
            }
            else numRead = 0;

            if (exitCondition != -1)
            {
                result[counter] = numRead;
                counter++;
            }
            left = 0; right = -1;
           
        }
        while (exitCondition != -1);

        for (int i = 0; i < counter; i++) Console.WriteLine(result[i]);
        

    }
}