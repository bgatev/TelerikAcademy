using System;
using System.Linq;

class Problem43DStars
{
    static void Main()
    {
        int starsCount = 0;
        int[] result = new int[26];

        string line = Console.ReadLine();
        string[] whd = line.Split(' ');
        int W = int.Parse(whd[0]), H = int.Parse(whd[1]), D = int.Parse(whd[2]);

        char[, ,] cuboid = new char[H, D, W];

        for (int i = 0; i < H; i++)
        {
            line = Console.ReadLine();
            string[] stringD = line.Split(' ');

            for (int j = 0; j < D; j++)
                for (int k = 0; k < W; k++) cuboid[i, j, k] = stringD[j][k];
        }

        for (int i = 1; i < H - 1; i++)
          for (int j = 1; j < D - 1; j++)
            for (int k = 1; k < W - 1; k++)
            {
                if ((cuboid[i, j, k] == cuboid[i, j, k - 1]) && (cuboid[i, j, k] == cuboid[i, j, k + 1]) && (cuboid[i, j, k] == cuboid[i, j - 1, k])
                    && (cuboid[i, j, k] == cuboid[i, j + 1, k]) && (cuboid[i, j, k] == cuboid[i - 1, j, k]) && (cuboid[i, j, k] == cuboid[i + 1, j, k]))
                {
                    starsCount++;
                    result[cuboid[i, j, k] - 'A']++;
                }
            }

        Console.WriteLine(starsCount);
        for (int i = 0; i < 26; i++) if (result[i] > 0) Console.WriteLine("{0} {1}", (char)(i + 'A'), result[i]); 
    }
}

