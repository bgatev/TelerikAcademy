//Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
//  A:  1 5  9 13   B:  1 8  9 16   C:  7 11 14 16  D:  1 12 11 10
//      2 6 10 14       2 7 10 15       4  8 12 15      2 13 16  9
//      3 7 11 15       3 6 11 14       2  5  9 13      3 14 15  8
//      4 8 12 16       4 5 12 13       1  3  6 10      4  5  6  7

using System;

class Spiral
{
    
    static void PrintMatrix(int[,] inMatrix, int n)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0} ",inMatrix[row,col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void MatrixA(int[,] inMatrix, int n)
    {
        for (int col = 0, i = 1; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                inMatrix[row, col] = i;
                i++;
            }
        }
    }

    static void MatrixB(int[,] inMatrix, int n)
    {
        int i = 1, col = 0, row = 0;

        do
        {
            //down
            for (row = 0; row < n; row++)
            {
                inMatrix[row, col] = i;
                i++;
            }
            col++;
            if (col >= n) break;
            
            //up
            for (row = n - 1; row > -1; row--)
            {
                inMatrix[row, col] = i;
                i++;
            }
            col++;
            if (col >= n) break;

        } while (i < n * n);
    }
    
    static void MatrixC(int[,] inMatrix, int n)
    {
        int num = 1, row = n - 1, col = 0, counter = 0;

        inMatrix[row, col] = num;
        num++;

        do
        {
            //up
            if (row > 0) row--;
            else col++;
            inMatrix[row, col] = num;
            num++;

            //right
            row++;
            col++;
            if (col >= n) break;

            do
            {
                inMatrix[row, col] = num;
                num++;
                row++;
                col++;
                counter++;
            } 
            while ((row < n) && (col < n));

            for (int i = 0; i < counter + 1; i++)
            {
                row--;
                col--;
            }
            counter = 0;

        } while (num <= n * n);
    }

    static void MatrixD(int[,] inMatrix, int n)
    {
        int row = 0, col = n, currentRow = 0, currentCol = 0, startPos = 0, num = 1;

        do
        {
            // down then right
            for (currentCol = startPos; currentCol < (n - startPos); currentCol++)
            {
                for (currentRow = row; currentRow < (n - startPos); currentRow++)
                {
                    inMatrix[currentRow, currentCol] = num;
                    num++;
                }
                row = currentRow - 1;
            }

            //row = currentRow - 1;
            row--;
            col--;

            // up then left
            for (currentCol = col; currentCol > startPos; currentCol--)
            {
                for (currentRow = row; currentRow >= startPos; currentRow--)
                {
                    inMatrix[currentRow, currentCol] = num;
                    num++;
                }
                row = currentRow + 1;
            }
            row++;
            startPos++;
        }
        while (startPos < n);
    }   

    static void Main()
    {
        int n;

        n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        MatrixA(matrix, n);
        PrintMatrix(matrix, n);
        MatrixB(matrix, n);
        PrintMatrix(matrix, n);
        MatrixC(matrix, n);
        PrintMatrix(matrix, n);
        MatrixD(matrix, n);
        PrintMatrix(matrix, n);
    }
}

