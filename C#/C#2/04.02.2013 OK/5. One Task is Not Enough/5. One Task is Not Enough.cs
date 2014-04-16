using System;
using System.Linq;
using System.Diagnostics;

class OneTaskisNotEnough
{
    static int TurnOnLamps(int[] lamps)
    {
        int actionsNumber = 2, result = 0, remainLampsOff = lamps.Length - 1;

        do
        {
            int counter = 0, lampsOn = remainLampsOff;
            
            for (int i = 1; i <= lampsOn; i++)
            {
                if (i == 1)
                {
                    result = lamps[i];
                    lamps[i] = 0;
                    remainLampsOff--;
                    continue;
                }
                else if (lamps[i] != 0)
                {
                    counter++;
                    if (counter == actionsNumber)
                    {
                        result = lamps[i];
                        lamps[i] = 0;
                        remainLampsOff--;
                        counter = 0;
                    }
                }
            }
            for (int j = 1, k = 1; j <= lampsOn; j++)
            {
                if (lamps[j] != 0)
                {
                    lamps[k++] = lamps[j];
                    lamps[j] = 0;
                }
            }

            actionsNumber++;
        }
        while (remainLampsOff > 0);

        return result;
    }

    static bool FindPathByAuthors(string commands)
    {
        int[] movesX = { 1, 0, -1, 0 };
        int[] movesY = { 0, 1, 0, -1 };

        // Starting from (0,0)
        int currentX = 0, currentY = 0, direction = 0;

        for (int i = 1; i <= 4; i++)
        {
            for (int j = 0; j < commands.Length; j++)
            {
                switch (commands[j])
                {
                    case 'S':
                        currentX += movesX[direction];
                        currentY += movesY[direction];
                        break;
                    case 'L':
                        direction = (direction + 3) % 4; // +270 degrees, turns left
                        break;
                    case 'R':
                        direction = (direction + 1) % 4; // +90 degrees, turns right
                        break;
                }
            }
        }

        if (currentX == 0 && currentY == 0) return true; // After 4 commands execution he is back on the starting place
        else return false; // He moved after 4 commands execution. He will move again and again in the same direction after every next commands execution
    }

    static void Main()
    {
        int N, lastLampOff = 0;
        string commands1 = string.Empty, commands2 = string.Empty;

        N = int.Parse(Console.ReadLine());
        commands1 = Console.ReadLine();
        commands2 = Console.ReadLine();

        int[] lamps = new int[N + 1];

        lamps[0] = 0;
        for (int i = 1; i <= N; i++) lamps[i] = i;

        Stopwatch sw = new Stopwatch();
        sw.Start();

        lastLampOff = TurnOnLamps(lamps);
        Console.WriteLine(lastLampOff);

        if (FindPathByAuthors(commands1)) Console.WriteLine("bounded");
        else Console.WriteLine("unbounded");

        if (FindPathByAuthors(commands2)) Console.WriteLine("bounded");
        else Console.WriteLine("unbounded");

        //sw.Stop();
        //Console.WriteLine(sw.Elapsed);
    }
}

