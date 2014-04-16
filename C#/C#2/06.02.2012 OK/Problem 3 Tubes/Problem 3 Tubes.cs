using System;
using System.Diagnostics;
using System.Linq;

class Problem3Tubes
{
    static int TubesByIvailo(int[] tubes, int maxTube, int M)
    {
        int left = 1, right = maxTube, middle = (left + right) / 2, result = -1;

        while (left <= right)
        {
            int eventual = 0;

            for (int j = 0; j < tubes.Length; j++) eventual += tubes[j] / middle;
            
            if (eventual < M) right = middle - 1;
            else if (eventual >= M)
            {
                left = middle + 1;
                result = middle;
            }

            middle = (left + right) / 2;
        }

        return result;
    }
    
    static void Main()
    {
        double sum = 0;
        int maxTube = 0;
        int approxValue;
        int N = int.Parse(Console.ReadLine());
        int[] tubes = new int[N];

        int M = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            tubes[i] = int.Parse(Console.ReadLine());
            sum += tubes[i];
            if (maxTube < tubes[i]) maxTube = tubes[i];
        }

        approxValue = TubesByIvailo(tubes, maxTube, M);
        /*
        approxValue = (int)(sum / M);
        
        if (sum < M)
        {
            Console.WriteLine(-1);
            Environment.Exit(0);
        }

        Stopwatch sw = new Stopwatch();
        sw.Start();

        do
        {
            bool founded = false;
            int currentM = 0;

            for (int i = 0; i < N; i++)
            {
                currentM += tubes[i] / approxValue;
                if ((currentM >= M) && (i != (N - 1))) break;
                if ((currentM == M) && (i == (N - 1))) founded = true;
            }

            if (founded) break;
            approxValue--;
        }
        while (approxValue > 0);
        sw.Stop();*/

        if (approxValue <= 0) Console.WriteLine(-1);
        else Console.WriteLine(approxValue);
        //Console.WriteLine(sw.Elapsed);
    }
}

