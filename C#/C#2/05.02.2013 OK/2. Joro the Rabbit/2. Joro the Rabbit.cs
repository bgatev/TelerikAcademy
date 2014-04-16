using System;
using System.Diagnostics;
using System.Linq;

class JorotheRabbit
{
    static void Main()
    {
        int currentResult = 0, maxResult = 1;
        string terrainStr = string.Empty;
       
        terrainStr = Console.ReadLine();

        Stopwatch sw = new Stopwatch();
        sw.Start();

        string[] terrainStrArray = terrainStr.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        int[] terrain = new int[terrainStrArray.Length];

        for (int i = 0; i < terrainStrArray.Length; i++) terrain[i] = int.Parse(terrainStrArray[i]);

        for (int step = 1; step <= terrain.Length; step++)
        {
            for (int i = 0, currentIndex = 0, nextIndex = 0; i < terrain.Length; i++)
            {
                currentIndex = i;
                nextIndex = currentIndex + step;
                if ((nextIndex / terrain.Length) > 0)
                {
                    if ((nextIndex % terrain.Length) == 0) nextIndex = 0;
                    else nextIndex = nextIndex % terrain.Length;
                }
                currentResult++;

                do
                {
                    if (terrain[currentIndex] < terrain[nextIndex])
                    {
                        currentResult++;
                        currentIndex = nextIndex;
                        nextIndex += step;
                        if ((nextIndex / terrain.Length) > 0)
                        {
                            if ((nextIndex % terrain.Length) == 0) nextIndex = 0;
                            else nextIndex = nextIndex % terrain.Length;
                        }
                    }
                    else break;
                }
                while (true);

                if (currentResult > maxResult) maxResult = currentResult;
                currentResult = 0;
            }
            if (maxResult == terrain.Length) break;
        }

        sw.Stop();
        Console.WriteLine(maxResult);

        //Console.WriteLine(sw.Elapsed);
    }
}