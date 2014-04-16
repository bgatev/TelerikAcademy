using System;
using System.Linq;

class Greedy_Dwarf
{
    static int[] SplitString(string inString)
    {
        string[] temp = inString.Split(',', ' ');
        int tempLength = 0;
        for (int i = 0; i < temp.Length; i++) if (temp[i] != "") tempLength++;

        int[] result = new int[tempLength];
        for (int i = 0, j = 0; i < temp.Length; i++) if (temp[i] != "") result[j++] = int.Parse(temp[i]);

        return result;
    }

    static int CalculateCoins(int[] valley, int[][] patterns)
    {
        int coins = 0, coinsMax = valley[0], col = 0;
        int[] temp = new int[valley.Length];

        for (int i = 0; i < valley.Length; i++) temp[i] = valley[i];
        
        for (int i = 0; i < patterns.GetLength(0); i++)
		{
            int pos = 0;
            
            for (int j = 0; j < valley.Length; j++) valley[j] = temp[j];
            coins = valley[0];
            valley[0] = 0;

            do   
            {
                if ((patterns[i][col] + pos) > (valley.Length - 1) || (patterns[i][col] + pos) < 0)
                {
                    if (coinsMax < coins) coinsMax = coins;
                    col = 0;
                    break;
                }

                if (valley[patterns[i][col] + pos] == 0)
                {
                    if (coinsMax < coins) coinsMax = coins;
                    col = 0;
                    break;
                }

                coins += valley[patterns[i][col] + pos];
                valley[patterns[i][col] + pos] = 0;
                pos += patterns[i][col];
                
                if (col < patterns[i].Length - 1) col++;
                else col = 0;
            }
            while (true);
        }

        return coinsMax;
    }

    static void Main()
    {
        string valleyStr = string.Empty;
        int M, coinsCollected = 0;

        valleyStr = Console.ReadLine();
        M = int.Parse(Console.ReadLine());
        
        int[] valley = SplitString(valleyStr);

        string[] patternsStr = new string[M];
        int[][] patterns = new int[M][];

        for (int i = 0; i < M; i++) patternsStr[i] = Console.ReadLine();

        for (int i = 0; i < M; i++)
        {
            int[] temp = SplitString(patternsStr[i]);
            patterns[i] = new int[temp.Length];

            for (int j = 0; j < temp.Length; j++) patterns[i][j] = temp[j];             
        }

        coinsCollected = CalculateCoins(valley, patterns);

        Console.WriteLine(coinsCollected);
    }
}

