using System;

class Carpets
{
    static char[,] matrix;
    static int N;
    static int upleftLimit, downrightLimit;

    static void Main()
    {
        int row, col;

        N = int.Parse(Console.ReadLine());
        
        upleftLimit = 0;
        downrightLimit = N;
        row = N / 2 - 1;
        col = 0;
        matrix = new char[N, N];

        for (int i = 0; i < N; i++) 
            for (int j = 0; j < N; j++) matrix[i, j] = '.';
        
        while (col < N / 2)
        {
            DrawRomb(row, col);
            col += 2;
            upleftLimit += 2;
            downrightLimit -= 2;
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++) Console.Write(matrix[i, j]);
            Console.WriteLine();
        }
    }

    static void DrawRomb(int row, int col)
    {
        int colSpace = 1;
        int verticalDirection = -1;
        int horyzontalDirection = 1;
        char symbol = '/';

        while (true)
        {
            matrix[row, col] = symbol;

            if ((((col + colSpace) >= upleftLimit) && ((col + colSpace) < downrightLimit)) && (matrix[row, col + colSpace] == '.')) matrix[row, col + colSpace] = ' ';
            
            col += horyzontalDirection;
            row += verticalDirection;

            // up and down
            if (row < upleftLimit)
            {
                verticalDirection = 1;
                colSpace = -1;
                row += verticalDirection;
                symbol = '\\';
            }
            else if (row >= downrightLimit)
            {
                verticalDirection = -1;
                colSpace = 1;
                row += verticalDirection;
                symbol = '\\';
            }

            // right and left
            if (col < upleftLimit)
            {
                horyzontalDirection = 1;
                col += horyzontalDirection;
                symbol = '\\';
            }
            else if (col >= downrightLimit)
            {
                horyzontalDirection = -1;
                col += horyzontalDirection;
                symbol = '/';
            }

            if (matrix[row, col] == '/') break;
        }
    }
}


