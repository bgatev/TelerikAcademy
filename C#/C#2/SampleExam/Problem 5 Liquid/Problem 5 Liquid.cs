using System;
using System.Linq;

class Problem5Liquid
{
    static void Main()
    {
        int liquidAmount = 0;
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

                for (int k = 0; k < W; k++) cuboid[i, j, k] = int.Parse(stringW[k]);
            }
        }

        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                int currentAmount = 0;

                for (int k = 0; k < D - 1; k++)
                {
                    if (cuboid[i, k, j] == 0)
                    {
                        currentAmount = 0;
                        break;
                    }
                    else if (cuboid[i, k + 1, j] > 0)
                    {
                        if (cuboid[i, k + 1, j] < cuboid[i, k, j]) currentAmount = cuboid[i, k + 1, j];
                        else currentAmount = cuboid[i, k, j];
                    }
                    else currentAmount = 0;
                }
                liquidAmount += currentAmount;
            }
        }


        Console.WriteLine(liquidAmount);


    }
}

