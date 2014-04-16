using System;
using System.Linq;

class Problem4BombingCuboids
{
    static double CalcEuclidianDistance3D(int h1, int d1, int w1, int h2, int d2, int w2)
    {
        //http://en.wikipedia.org/wiki/Euclidean_distance

        double distance = Math.Sqrt((h1 - h2) * (h1 - h2) + (d1 - d2) * (d1 - d2) + (w1 - w2) * (w1 - w2));
        
        return distance;
    }

    static void Main()
    {
        int destroyedCubes = 0;
        int[] result = new int[26];

        string line = Console.ReadLine();
        string[] whd = line.Split(' ');
        int W = int.Parse(whd[0]), H = int.Parse(whd[1]), D = int.Parse(whd[2]);

        int[, ,] cuboid = new int[H, D, W];

        for (int i = 0; i < H; i++)
        {
            line = Console.ReadLine();
            string[] stringD = line.Split(' ');

            for (int j = 0; j < D; j++)
                for (int k = 0; k < W; k++) cuboid[i, j, k] = stringD[j][k];
        }

        int N = int.Parse(Console.ReadLine());
        int[][] bombs = new int[N][];

        for (int i = 0; i < N; i++) bombs[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        foreach (int[] bomb in bombs)
        {
            bool[,] hasDestroyed = new bool[W, D];

            for (int i = 0; i < W; i++) //destroy cubes
                for (int j = 0; j < D; j++)
                    for (int k = 0; k < H; k++)
                    {
                        if (cuboid[k, j, i] == '\0') break;
                        if (CalcEuclidianDistance3D(k, j, i, bomb[1], bomb[2], bomb[0]) <= bomb[3])
                        {
                            hasDestroyed[i, j] = true;
                            result[cuboid[k, j, i] - 'A'] += 1;
                            destroyedCubes++;
                            cuboid[k, j, i] = '\0';
                        }
                    }
            for (int i = 0; i < W; i++) //rearrange cuboid
                for (int j = 0; j < D; j++)
                {
                    if (!hasDestroyed[i, j]) continue;
                    int holes = 0;

                    for (int k = 0; k < H; k++)
                    {
                        if (cuboid[k, j, i] == '\0') holes++;
                        else if (holes != 0)
                        {
                            cuboid[k - holes, j, i] = cuboid[k, j, i];
                            cuboid[k, j, i] = '\0';
                        }
                        
                    }
                }
        }

        Console.WriteLine(destroyedCubes);
        for (int i = 0; i < 26; i++) if (result[i] > 0) Console.WriteLine("{0} {1}", (char)(i + 'A'), result[i]); 
    }
}
