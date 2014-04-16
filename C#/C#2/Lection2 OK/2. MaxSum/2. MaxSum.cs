//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

// 12345679
// 12345678
// 12345678
// 12345678

using System;

class MaxSum
{
    static void InputMatrix(int[,] inMatrix, int n, int m)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                inMatrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine();
    }
    
    static int FindSquareSum(int[,] inMatrix, int startRow, int startCol, int sizeRow, int sizeCol)
    {
        int sum = 0;

        for (int row = startRow; row < (startRow + sizeRow); row++)
		{
			for (int col = startCol; col < (startCol + sizeCol); col++)
			{
			    sum += inMatrix[row,col];
			}
		}
        return sum;
    }

    static int FindSquareMaxSum(int[,] inMatrix, int n, int m, int sizeRow, int sizeCol)
    {
        int tempsum = 0, maxSum = int.MinValue;

        for (int row = 0; row < inMatrix.GetLength(0) - sizeRow + 1; row++)
        {
            for (int col = 0; col < inMatrix.GetLength(1) - sizeCol + 1; col++)
            {
                tempsum = FindSquareSum(inMatrix, row, col, sizeRow, sizeCol);
                if (tempsum > maxSum) maxSum = tempsum;
            }
        }
        return maxSum;
    }

    static void PrintMatrix(int[,] inMatrix, int n, int m)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("{0} ", inMatrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
    static void Main()
    {
        int N, M, squareMaxSum = 0, squareRowSize = 3, squareColSize = 3;

        N = int.Parse(Console.ReadLine());
        M = int.Parse(Console.ReadLine());

        int[,] matrix = new int[N, M];

        InputMatrix(matrix, N, M);

        squareMaxSum = FindSquareMaxSum(matrix, N, M, squareRowSize, squareColSize);

        PrintMatrix(matrix, N, M);
        Console.WriteLine("Max Sum of square with size {0}x{1} is {2}", squareRowSize, squareColSize,squareMaxSum);
    }
}

