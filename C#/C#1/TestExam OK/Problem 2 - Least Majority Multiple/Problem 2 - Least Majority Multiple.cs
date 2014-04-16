using System;

class Problem2LeastMajorityMultiple
{
    static int[] primeNumbers = new int[25];
    static int[] dNum = new int[6];

    static void Main()
    {
        int a, b, c, d, e, LMM3of5 = 0, flag = 0;
        int[] dNumbers = new int[30];

        a = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        c = int.Parse(Console.ReadLine());
        d = int.Parse(Console.ReadLine());
        e = int.Parse(Console.ReadLine());

        // all prime numbers from 1 to 100
        for (int i = 1, k = 0; i < 101; i++, k++)
        {
            for (int j = 1; j < i; j++)
            {
                if (i % j == 0) flag++;
                if (flag > 1) break;
            }
            if (flag == 1) primeNumbers[k] = i;
            else k--;
            flag = 0;
        }

        Deletion(a);
        for (int i = 0; i < 6; i++) dNumbers[i] = dNum[i];
        Deletion(b);
        for (int i = 0; i < 6; i++) dNumbers[i + 6] = dNum[i];
        Deletion(c);
        for (int i = 0; i < 6; i++) dNumbers[i + 12] = dNum[i];
        Deletion(d);
        for (int i = 0; i < 6; i++) dNumbers[i + 18] = dNum[i];
        Deletion(e);
        for (int i = 0; i < 6; i++) dNumbers[i + 24] = dNum[i];

        for (int i = 0; i < 30; i++)
        {

        }

        //Simple solution, but not right for many numbers
        /*for (int i = 1, count = 0; i < 1000000; i++)
        {
            if (i % a == 0) count++;
            if (i % b == 0) count++;
            if (i % c == 0) count++;
            if (i % d == 0) count++;
            if (i % e == 0) count++;
            if (count >= 3)
            {
                LMM3of5 = i;
                break;
            }
            count = 0;
        }*/

        Console.WriteLine(LMM3of5);
    }

    static void Deletion(int num)
    {
        int j = 0;

        for (int i = 0; i < 6; i++) dNum[i] = 0;

        for (int i = 0; i < 25; i++)
        {
            while (true)
            {
                if (num % primeNumbers[i] != 0) break;
                else
                {
                    num /= primeNumbers[i];
                    dNum[j++] = primeNumbers[i];
                }
            }
        }
    }

}

