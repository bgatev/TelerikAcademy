namespace Matrix
{
    using System;

    public class WalkInMatrix 
    {
        public static int[] ChangeDirection(int dx, int dy) 
        {
            int[] newCell = new int[2];

            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            
            for (int i = 0; i < 8; i++)
            {
                if (dirX[i] == dx && dirY[i] == dy) 
                {
                    if (i == 7)
                    {
                        newCell[0] = dirX[0];
                        newCell[1] = dirY[0];
                    }
                    else
                    {
                        newCell[0] = dirX[i + 1];
                        newCell[1] = dirY[i + 1];
                    }

                    return newCell;
                }
            }

            return newCell;
        }

        public static bool IsCellEmpty(int[,] matrixToCheck, int row, int col)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (row + dirX[i] >= matrixToCheck.GetLength(0) || row + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (col + dirY[i] >= matrixToCheck.GetLength(0) || col + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }

                if (matrixToCheck[row + dirX[i], col + dirY[i]] == 0)
                {
                    return true;
                }
            }
            
            return false;
        }

        public static int[] FindNextEmptyCell(int[,] currentMatrix)
        {
            int[] emptyCell = new int[2] { 0, 0 };

            for (int currentRow = 0; currentRow < currentMatrix.GetLength(0); currentRow++)
            {
                for (int currentCol = 0; currentCol < currentMatrix.GetLength(0); currentCol++)
                {
                    if (currentMatrix[currentRow, currentCol] == 0)
                    {
                        emptyCell[0] = currentRow;
                        emptyCell[1] = currentCol;
                        
                        return emptyCell;
                    }
                }
            }

            return emptyCell;
        }

        public static void PrintMatrix(int[,] matrixToPrint)
        {
            for (int row = 0; row < matrixToPrint.GetLength(0); row++)
            {
                for (int col = 0; col < matrixToPrint.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrixToPrint[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void Main()
        {
            int n = 0;

            while (n <= 0 || n > 100)
            {
                Console.Write("Enter a positive number between 0 and 100: ");
                n = int.Parse(Console.ReadLine());
            }
            
            // int n = 13;
            int[,] matrix = new int[n, n];
            int cellValue = 1, row = 0, col = 0;

            while (true)
            {
                int dx = 1;
                int dy = 1;

                while (true)
                {
                    matrix[row, col] = cellValue;

                    if (!IsCellEmpty(matrix, row, col))
                    {
                        break;
                    }
                    
                    if (row + dx >= n || row + dx < 0 || col + dy >= n || col + dy < 0 || matrix[row + dx, col + dy] != 0)
                    {
                        while (row + dx >= n || row + dx < 0 || col + dy >= n || col + dy < 0 || matrix[row + dx, col + dy] != 0)
                        {
                            int[] currentCell = ChangeDirection(dx, dy);
                            dx = currentCell[0];
                            dy = currentCell[1];
                        }
                    }

                    row += dx;
                    col += dy;
                    cellValue++;                    
                }

                cellValue++;

                int[] currentEmptyCell = FindNextEmptyCell(matrix);
                row = currentEmptyCell[0];
                col = currentEmptyCell[1];
                if (row == 0 && col == 0)
                {
                    break;
                }
            }

            PrintMatrix(matrix);
        }
    }
}
