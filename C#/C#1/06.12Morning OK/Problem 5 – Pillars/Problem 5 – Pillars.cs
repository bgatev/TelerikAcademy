using System;

class Problem5Pillars
{
    static void Main()
    {
        int left1=0, right1=0, flag=0;
        int[] inputN = new int[8];
        int[] outputN = new int[8];

        for (int i = 0; i < 8; i++) inputN[i] = int.Parse(Console.ReadLine());
        
        for (int i = 7; i >= 0; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                outputN[j] = inputN[j] & ~(1 << i);
                for (int k = i + 1; k < 8; k++) if ((outputN[j] & (1 << k)) != 0) left1++;       //k bit=1
                for (int k = 0; k < i; k++) if ((outputN[j] & (1 << k)) != 0) right1++;          //k bit=1
            }
            if (left1 == right1)
            {
                Console.WriteLine(i);
                Console.WriteLine(left1);
                break;
            }
            left1 = 0;
            right1 = 0;
            if (i == 0) flag = 1;
        }
        if (flag == 1) Console.WriteLine("No");

    }
}

