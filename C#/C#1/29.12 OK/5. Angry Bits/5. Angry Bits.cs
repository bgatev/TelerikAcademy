using System;

class AngryBits
{
    
    static int[,] matrix = new int[8, 16];
    static int score = 0;

    static void Main()
    {
        int flightLenght = 0;
        int row, col;

        for (int i = 0, readnum = 0; i < 8; i++)
        {
            readnum = int.Parse(Console.ReadLine());
            for (int j = 0; j < 16; j++) matrix[i, 15-j] = (readnum & (1 << j)) >> j; //move every bit to a single matrix value
        }

        //print matrix
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 16; j++) Console.Write(matrix[i, j]);
            Console.WriteLine();
        }

                       
        for (int i = 7; i > -1; i--)
        {
            int verticalDirection = -1;
            int horyzontalDirection = 1;
            flightLenght = 0;
            row = FindBird(i);
            col = i;
            
            if (row != 8)
            {
                while (true)
                {
                    matrix[row, col] = 0;
                    flightLenght++;
                    
                    row += verticalDirection;
                    col += horyzontalDirection;

                    // up and down
                    if (row < 0)
                    {
                        verticalDirection = 1;
                        row += 2;
                    }
                    else if (row > 7) break;
                    
                    // right and left
                    if (col > 15) break;
                                       
                    //hit pig
                    if (matrix[row, col] == 1)
                    {
                        matrix[row, col] = 0;
                        score += flightLenght * (1 + PigClear(row, col));
                        break;
                    }
                    else matrix[row, col] = 1;      //no pig hit, just flying
                    
                }   
            }
        }
        
        //print result
        for (int i = 0, count = 0; i < 8; i++)
        {
            for (int j = 8; j < 16; j++) if (matrix[i, j] == 0) count++;
            if (count == 64) Console.WriteLine("{0} Yes", score);
            else if (i == 7) Console.WriteLine("{0} No", score);
        }
           
    }

    static int FindBird(int col)
    {
        for (int i = 0; i < 8; i++) if (matrix[i, col] == 1) return i;
              
        return 8;
    }

    static int PigClear(int rowHit, int colHit)
    {
        int pigCount = 0;

        //clear right pig
        if (colHit < 15) if (matrix[rowHit,colHit+1] == 1)
        {
            matrix[rowHit, colHit + 1] = 0;
            pigCount++;
        }
        //clear left pig
        if (colHit > 8) if (matrix[rowHit, colHit - 1] == 1)
        {
            matrix[rowHit, colHit - 1] = 0;
            pigCount++;
        }
        //clear up pigs
        if ((rowHit > 0) && (colHit > 8)) if (matrix[rowHit-1, colHit - 1] == 1)
        {
            matrix[rowHit - 1, colHit - 1] = 0;
            pigCount++;
        }
        if (rowHit > 0) if (matrix[rowHit - 1, colHit] == 1)
        {
            matrix[rowHit - 1, colHit] = 0;
            pigCount++;
        }
        if ((rowHit > 0) && (colHit < 15)) if (matrix[rowHit - 1, colHit + 1] == 1)
        {
            matrix[rowHit - 1, colHit + 1] = 0;
            pigCount++;
        }
        //clear down pigs
        if ((rowHit < 7) && (colHit > 8)) if (matrix[rowHit + 1, colHit - 1] == 1)
        {
            matrix[rowHit + 1, colHit - 1] = 0;
            pigCount++;
        }
        if (rowHit < 7) if (matrix[rowHit + 1, colHit] == 1)
        {
            matrix[rowHit + 1, colHit] = 0;
            pigCount++;
        }
        if ((rowHit < 7) && (colHit < 15)) if (matrix[rowHit + 1, colHit + 1] == 1)
        {
            matrix[rowHit + 1, colHit + 1] = 0;
            pigCount++;
        }
        
        return pigCount;
    }
}

