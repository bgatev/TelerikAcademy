using System;

class Problem5Lines
{
    static void Main()
    {
        int maxLineLenght = 0, maxLineNum = 0;
        int[] n = new int[8];
        int[] currentLL = new int[8];
        int[] maxLR = new int[8];
        int[] maxLC = new int[8];
        int[] maxLRN = new int[8];
        int[] maxLCN = new int[8];

        for (int i = 0; i < 8; i++) n[i] = int.Parse(Console.ReadLine());
                
        for (int i = 0; i < 8; i++)             //check rows
        {
            for (int j = 0; j < 8; j++)
            {
                if ((n[j] & (1 << i)) != 0)
                {
                    currentLL[j]++;
                    if (currentLL[j] > maxLR[j])
                    {
                        maxLR[j] = currentLL[j];
                        maxLRN[j] = 1;
                    }
                    else if (currentLL[j] == maxLR[j]) maxLRN[j]++;
                }
                else currentLL[j] = 0;
            }
        }
        for (int i = 0; i < 8; i++) currentLL[i] = 0;
           
        for (int i = 0; i < 8; i++)             //check cols
        {
            for (int j = 0; j < 8; j++)
            {
                if ((n[j] & (1 << i)) != 0)
                {
                    currentLL[i]++;
                    if (currentLL[i] > maxLC[i])
                    {
                        maxLC[i] = currentLL[i];
                        maxLCN[i] = 1;
                    }
                    else if (currentLL[i] == maxLC[i]) maxLCN[i]++;
                }
                else currentLL[i] = 0;
            }
        }
        
        for (int i = 0; i < 8; i++)
        {
            if (maxLR[i] > maxLineLenght)
            {
                maxLineLenght = maxLR[i];
                maxLineNum = maxLRN[i];
            }
            else if (maxLR[i] == maxLineLenght) maxLineNum += maxLRN[i];
           
            if (maxLC[i] > maxLineLenght)
            {
                maxLineLenght = maxLC[i];
                maxLineNum = maxLCN[i];
            }
            else if (maxLC[i] == maxLineLenght) maxLineNum += maxLCN[i];
        }
        if (maxLineLenght == 1) maxLineNum /= 2;

        /*for (int i = 0; i < 8; i++) Console.Write("{0} ", maxLR[i]); Console.WriteLine();
        for (int i = 0; i < 8; i++) Console.Write("{0} ", maxLRN[i]); Console.WriteLine();
        for (int i = 0; i < 8; i++) Console.Write("{0} ", maxLC[i]); Console.WriteLine();
        for (int i = 0; i < 8; i++) Console.Write("{0} ", maxLCN[i]); Console.WriteLine();*/
        
        Console.WriteLine(maxLineLenght);
        Console.WriteLine(maxLineNum);

    }

}

