using System;
using System.Linq;
using System.Text;

class Problem3Indices
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] ARR = new int[N];
        bool[] ARRBool = new bool[N];

        string line = Console.ReadLine();
        string[] lineStr = line.Split(' ');

        for (int i = 0; i < N; i++)
        {
            ARR[i] = int.Parse(lineStr[i]);
            ARRBool[i] = false;
        }

        StringBuilder sb = new StringBuilder();
        int currentIndex = 0, loopStart = -1;

        do
        {
            if ((currentIndex < 0) || (currentIndex >= N)) break;
            if (ARRBool[currentIndex])
            {
                loopStart = currentIndex;
                break;
            }

            sb.Append(currentIndex);
            sb.Append(' ');
            ARRBool[currentIndex] = true;
            currentIndex = ARR[currentIndex];
        }
        while(true);

        if (loopStart >= 0)
        {
            int index = sb.ToString().IndexOf((" " + loopStart + " ").ToString());

            if (index < 0) sb.Insert(0, '(');
            else sb[index] = '(';
            sb[sb.Length - 1] = ')';
        }
        
        Console.WriteLine(sb.ToString().Trim());
    }
}

