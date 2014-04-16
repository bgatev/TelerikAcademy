using System;

class BitBall
{
    static void Main()
    {
        int[] topTeam = new int[8];
        int[] bottomTeam = new int[8];
        int X = 0, Y = 0, count = 0;

        for (int i = 0; i < 8; i++) topTeam[i] = int.Parse(Console.ReadLine());
        for (int i = 0; i < 8; i++) bottomTeam[i] = int.Parse(Console.ReadLine());

        // red cards
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (((topTeam[i] & (1 << j)) != 0) && ((bottomTeam[i] & (1 << j)) != 0))
                {
                    topTeam[i] &= ~(1 << j);
                    bottomTeam[i] &= ~(1 << j);
                }
            }
        }

        //play game
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((topTeam[i] & (1 << j)) != 0) 
                {
                    for (int k = i + 1; k < 8; k++) if (((bottomTeam[k] & (1 << j)) == 0) && ((topTeam[k] & (1 << j)) == 0)) count++;
                    if (count == 7 - i) X++;
                }
                count = 0;
                if ((bottomTeam[i] & (1 << j)) != 0)
                {
                    for (int k = 0; k < i; k++) if (((topTeam[k] & (1 << j)) == 0) && ((bottomTeam[k] & (1 << j)) == 0)) count++;
                    if (count == i) Y++;
                }
                count = 0;
            }
        }

        Console.WriteLine("{0}:{1}",X,Y);
    }
}

