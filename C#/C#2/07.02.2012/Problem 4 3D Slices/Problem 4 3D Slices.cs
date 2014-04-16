using System;
using System.Linq;

class Problem43DSlices
{
    static void Main()
    {
        int totalSplits = 0;
        double cuboidSum = 0;

        string line = Console.ReadLine();
        string[] whd = line.Split(' ');
        int W = int.Parse(whd[0]), H = int.Parse(whd[1]), D = int.Parse(whd[2]);

        int[, ,] cuboid = new int[H, D, W];

        for (int i = 0; i < H; i++)
        {
            line = Console.ReadLine();
            string[] stringD = line.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < D; j++)
            {
                string[] stringW = stringD[j].Split(' ');

                for (int k = 0; k < W; k++)
                {
                    cuboid[i, j, k] = int.Parse(stringW[k]);
                    cuboidSum += cuboid[i, j, k];
                }
            }
        }

        int currentSum = 0;
        for (int i = 0; i < H - 1; i++)
        {            
            for (int j = 0; j < D; j++)
                for (int k = 0; k < W; k++) currentSum += cuboid[i, j, k];
               
            if (currentSum == cuboidSum / 2) totalSplits++;
        }

        currentSum = 0;
        for (int i = 0; i < D - 1; i++)
        {
            for (int j = 0; j < H; j++)
                for (int k = 0; k < W; k++) currentSum += cuboid[j, i, k];
                
            if (currentSum == cuboidSum / 2) totalSplits++;
        }

        currentSum = 0;
        for (int i = 0; i < W - 1; i++)
        {
            for (int j = 0; j < D; j++)
                for (int k = 0; k < H; k++) currentSum += cuboid[k, j, i];
                
            if (currentSum == cuboidSum / 2) totalSplits++;
        }

        if ((H == 1) && (D == 1) && (W == 1)) Console.WriteLine(0);
        else Console.WriteLine(totalSplits);
    }
}

