using System;
using System.Diagnostics;
using System.Linq;

class ThreeinOne
{
    static int BlackJack(int[] points)
    {
        int winner = -1;

        int[] temp = new int[points.Length];

        for (int i = 0; i < points.Length; i++) temp[i] = points[i];
        Array.Sort(temp);

        for (int i = temp.Length - 1; i > -1; i--)
        {
            if (temp[i] <= 21)
            {
                if (temp[i - 1] == temp[i]) return -1;
                else for (int j = 0; j < points.Length; j++) if (points[j] == temp[i]) return j;
            }
        }

        return winner;
    }

    static int Birtday(int[] sizes, int F)
    {
        int bites = 0;

        Array.Sort(sizes);
        Array.Reverse(sizes);

        for (int i = 0; i < sizes.Length; i += (F + 1)) bites += sizes[i];
        
        return bites;
    }

    static int Exchange(int[] coins)
    {
        int ops = 0, minOps = int.MaxValue;

        while (coins[3] > coins[0])
        {
            if (coins[3] > coins[0])
            {
                coins[3]--;
                coins[4] += 11;
                ops++;
            }
        }

        while (coins[4] > coins[1])
        {
            if (coins[0] > coins[3])
            {
                coins[0]--;
                coins[1] += 9;
                ops++;
            }
            else
            {
                coins[4]--;
                coins[5] += 11;
                ops++;
            }
        }

        while (coins[5] > coins[2])
        {
            if (coins[1] > coins[4])
            {
                coins[1]--;
                coins[2] += 9;
                ops++;
            }
            else if (coins[0] > coins[3])
            {
                coins[0]--;
                coins[1] += 9;
                ops++;
            }
            else return -1;
        }

        if (minOps > ops) minOps = ops;

        return minOps;
    }

    static void Main()
    {
        string line = string.Empty;
        int winner = -1, F, bites = 0, minOps = 0;
        
        Stopwatch sw = new Stopwatch();

        line = Console.ReadLine();
        string[] lineStr = line.Split(',');
        int[] points = new int[lineStr.Length];

        for (int i = 0; i < lineStr.Length; i++) points[i] = int.Parse(lineStr[i]);

        line = Console.ReadLine();
        string[] line2Str = line.Split(',');
        int[] sizes = new int[line2Str.Length];

        for (int i = 0; i < line2Str.Length; i++) sizes[i] = int.Parse(line2Str[i]);
        F = int.Parse(Console.ReadLine());

        line = Console.ReadLine();

        sw.Start();

        string[] line3Str = line.Split(' ');
        int[] coins = new int[line3Str.Length];

        for (int i = 0; i < line3Str.Length; i++) coins[i] = int.Parse(line3Str[i]);

        winner = BlackJack(points);
        Console.WriteLine(winner);

        bites = Birtday(sizes, F);
        Console.WriteLine(bites);

        minOps = Exchange(coins);
        Console.WriteLine(minOps);
        sw.Stop();
        //Console.WriteLine(sw.Elapsed);
    }
}

