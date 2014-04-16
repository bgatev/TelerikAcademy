using System;

class FormulaBit1
{
    static void Main()
    {
        int[] inputN = new int[8];
        int X = 0, Y = 0, row = 0, col = 0, flag = 0, flag1 = 0, fFirst = 0;
        int[] outputN = new int[8];

        for (int i = 0; i < 8; i++) inputN[i] = int.Parse(Console.ReadLine());

        for (int j = 0; j < 4; j++)
        {
            for (int i = row, ff = 0; i < 8; i++)   //check down
            {
                if ((inputN[row] & (1 << col)) == 0)
                {
                    X++;
                    row++;
                    fFirst = 1;
                    ff = 1;
                }
                else if (fFirst == 0) break;
                else
                {
                    if (ff == 0) flag1++;
                    Y++;
                    row--;
                    if (col < 7) col++;
                    break;
                }
                if (row == 8)
                {
                    Y++;
                    row--;
                    if (col < 6) col++;
                    else if (col == 6)
                    {
                        X++;
                        Y++;
                        col++;
                    }
                }
            }
            if (row == 7 && col == 7)
            {
                flag = 1;
                break;
            }
            else if ((fFirst == 0)  || (flag1 == 1)) break;

            for (int i = col, ff = 0; i < 8; i++)  //check left
            {
                if ((inputN[row] & (1 << i)) == 0)
                {
                    X++;
                    col++;
                    ff = 1;
                }
                else
                {
                    if (ff == 0) flag1++;
                    Y++;
                    if (row > 0) row--;
                    col--;
                    break;
                }
                if (col == 8)
                {
                    Y++;
                    if (row > 0) row--;
                    col--;
                }
            }
            if (row == 7 && col == 7)
            {
                flag = 1;
                break;
            }
            else if (flag1 == 1) break;
            
            for (int i = row, ff = 0; i > -1; i--)   //check up
            {
                if ((inputN[i] & (1 << col)) == 0)
                {
                    X++;
                    row--;
                    ff = 1;
                }
                else
                {
                    if (ff == 0) flag1++;
                    Y++;
                    row++;
                    if (col < 7) col++;
                    break;
                }
                if (row == -1)
                {
                    Y++;
                    row++;
                    if (col < 7) col++;
                    else flag1 = 1;
                }
            }
            if (row == 7 && col == 7)
            {
                flag = 1;
                break;
            }
            else if (flag1 == 1) break;

            for (int i = col, ff = 0; i < 8; i++)  //check left
            {
                if ((inputN[row] & (1 << i)) == 0)
                {
                    X++;
                    col++;
                    ff = 1;
                }
                else
                {
                    if (ff == 0) flag1++;
                    Y++;
                    if (row < 7) row++;
                    col--;
                    break;
                }
                if (col == 8)
                {
                    Y++;
                    if (row < 7) row++;
                    col--;
                }
            }
            if (row == 7 && col == 7)
            {
                flag = 1;
                break;
            }
            else if (flag1 == 1) break;

        }

        if (fFirst == 0) Console.WriteLine("No 0");
        else if (flag == 1) Console.WriteLine("{0} {1}", X, Y - 1);
        else Console.WriteLine("No {0}",X);
        

    }
}

