using System;

class TelerikLogo
{
    static void Main()
    {
        int X, Y, Z, row, col, matrixSize, hDirection, vDirection;

        X = int.Parse(Console.ReadLine());
        Y = X;
        Z = X / 2 + 1;
        matrixSize = 3 * X - 2;
        char[,] matrix = new char[matrixSize, matrixSize];

        for (int i = 0; i < matrixSize; i++)
            for (int j = 0; j < matrixSize; j++) matrix[i, j] = '.';

        row = Z-1;
        col = 0;
	    hDirection = 1;
	    vDirection = -1;
        while (true)
        {
            matrix[row, col] = '*';
            row += vDirection;
            col += hDirection;

            if (col < 0) col = 0;   //exception for X=3
            if (row == 0) vDirection = 1;
            else if (row == matrixSize)
		    {
		        vDirection = -1;
                row--;              //exception for last row
                row += vDirection;
		    }
            
            if ((row > matrixSize / 2) && (col == matrixSize - X / 2))
            {
		        hDirection = -1;
                if (row > matrixSize / 2) col--;
                col += hDirection;
            }
            else if (((row > matrixSize / 2) && (col == X / 2 - 1)) || (X == 3 && (col == X / 2 - 1)))  //exception for X=3, because when X=3 row < matrixSize/2
		    {
		        hDirection = 1;
                col++;
                col += hDirection;
		    }
            
            if ((row == Z - 1) && (col == matrixSize - 1))  //last symbol to display
            {
                matrix[row, col] = '*';
                break;
            }
        }

        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++) Console.Write(matrix[i, j]);
            Console.WriteLine();
        }
    }
}

