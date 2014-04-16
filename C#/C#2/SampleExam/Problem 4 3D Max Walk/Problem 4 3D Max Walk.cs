using System;
using System.Linq;

class Problem43DMaxWalk
{
    static bool MaxEl(int[, ,] cuboid, ref int currentH, ref int currentD, ref int currentW)
    {
        int maxValue = int.MinValue;
        int indexH = -1, indexD = -1, indexW = -1;

        for (int i = 0; i < cuboid.GetLength(0); i++)
        {
            if (i != currentH)
            {
                if (cuboid[i, currentD, currentW] > maxValue)
                {
                    indexH = i;
                    maxValue = cuboid[indexH, currentD, currentW];
                }
                else if (cuboid[i, currentD, currentW] == maxValue) indexH = -1;
            }
        }

        for (int i = 0; i < cuboid.GetLength(1); i++)
        {
            if (i != currentD)
            {
                if (cuboid[currentH, i, currentW] > maxValue)
                {
                    indexH = -1;
                    indexD = i;
                    maxValue = cuboid[currentH, indexD, currentW];
                }
                else if (cuboid[currentH, i, currentW] == maxValue)
                {
                    indexH = -1;
                    indexD = -1;
                }
            }
        }

        for (int i = 0; i < cuboid.GetLength(2); i++)
        {
            if (i != currentW)
            {
                if (cuboid[currentH, currentD, i] > maxValue)
                {
                    indexH = -1;
                    indexD = -1;
                    indexW = i;
                    maxValue = cuboid[currentH, currentD, indexW];
                }
                else if (cuboid[currentH, currentD, i] == maxValue)
                {
                    indexH = -1;
                    indexD = -1;
                    indexW = -1;
                }
            }
        }

        if (indexH != -1) currentH = indexH;
        else if (indexD != -1) currentD = indexD;
        else if (indexW != -1) currentW = indexW;
        else return false;

        return true;
    }
    
    static bool MaxOf6(int[, ,] cuboid, ref int currentH, ref int currentD, ref int currentW)
    {
        int[] allValues = new int[6] {int.MinValue , int.MinValue, 
                                       int.MinValue, int.MinValue,
                                       int.MinValue, int.MinValue};
        
        int[] temp = new int[6] { int.MinValue, int.MinValue, 
                                       int.MinValue, int.MinValue,
                                       int.MinValue, int.MinValue};

        if (currentH > 0)
        {
            allValues[0] = cuboid[currentH - 1, currentD, currentW];
            temp[0] = cuboid[currentH - 1, currentD, currentW];
        }
        if (currentH < cuboid.GetLength(0) - 1)
        {
            allValues[1] = cuboid[currentH + 1, currentD, currentW];
            temp[1] = cuboid[currentH + 1, currentD, currentW];
        }

        if (currentD > 0)
        {
            allValues[2] = cuboid[currentH, currentD - 1, currentW];
            temp[2] = cuboid[currentH, currentD - 1, currentW];
        }
        if (currentD < cuboid.GetLength(1) - 1)
        {
            allValues[3] = cuboid[currentH, currentD + 1, currentW];
            temp[3] = cuboid[currentH, currentD + 1, currentW];
        }

        if (currentW > 0)
        {
            allValues[4] = cuboid[currentH, currentD, currentW - 1];
            temp[4] = cuboid[currentH, currentD, currentW - 1];
        }
        if (currentW < cuboid.GetLength(2) - 1)
        {
            allValues[5] = cuboid[currentH, currentD, currentW + 1];
            temp[5] = cuboid[currentH, currentD, currentW + 1];
        }

        Array.Sort(temp);
        if (temp[5] == temp[4]) return false;
        else
        {

            int indexMax = Array.IndexOf(allValues, temp[5]);

            switch (indexMax)
            {
                case 0: currentH--; break;
                case 1: currentH++; break;
                case 2: currentD--; break;
                case 3: currentD++; break;
                case 4: currentW--; break;
                case 5: currentW++; break;
            }
        }

        return true;
    }
    
    static void Main()
    {
        int maxWalk = 0;

        string line = Console.ReadLine();
        string[] whd = line.Split(' ');
        int W = int.Parse(whd[0]), H = int.Parse(whd[1]), D = int.Parse(whd[2]);
        int WStart, HStart, DStart;

        if (W > 1) WStart = W / 2;
        else WStart = 0;
        
        if (H > 1) HStart = H / 2;
        else HStart = 0;
        
        if (D > 1) DStart = D / 2;
        else DStart = 0;

        int[, ,] cuboid = new int[H, D, W];
        bool[, ,] visited = new bool[H, D, W];
        
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
                    visited[i, j, k] = false;
                }
            }
        }
        
        
        int currentH = HStart, currentD = DStart, currentW = WStart;
        maxWalk = cuboid[HStart, DStart, WStart];
        visited[HStart, DStart, WStart] = true;

        do
        {
            if (MaxEl(cuboid, ref currentH, ref currentD, ref currentW) && (!visited[currentH, currentD, currentW]))
            {
                maxWalk += cuboid[currentH, currentD, currentW];
                visited[currentH, currentD, currentW] = true;
            }
            else break;

        }
        while (true);

        Console.WriteLine(maxWalk);
    }
}

