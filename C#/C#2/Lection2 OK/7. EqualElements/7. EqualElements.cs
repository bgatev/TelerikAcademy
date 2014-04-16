//* Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.
//Hint: you can use the algorithm "Depth-first search" or "Breadth-first search" (find them in Wikipedia).
// 1 3 2 2 2 4
// 3 3 3 2 4 4
// 4 3 1 2 3 3 - > 13
// 4 3 1 3 3 1
// 4 3 3 3 1 1 

using System;
using System.Collections.Generic;

public class EqualElements
{
    static bool[,] Visited;

    public struct Point
    {
        public int row;
        public int col;

        public Point(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    static void InputMatrix(int[,] inMatrix, int rowSize, int colSize)
    {
        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {
                inMatrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine();
    }

    static void TryVisit(int[,] inMatrix, Queue<Point> q, int row, int col, int previousCell)
    {
        if ((row >= 0) && (row < inMatrix.GetLength(0)) && (col >= 0) && (col < inMatrix.GetLength(1)))
        {
            if (!Visited[row, col])
            {
                if (inMatrix[row, col] == previousCell)
                {
                    q.Enqueue(new Point(row, col));
                    Visited[row, col] = true;
                }
            }
        }
    }

    static int BFS(int[,] inMatrix, int row, int col)
    {
        Queue<Point> q = new Queue<Point>();
        int counter = 0, currentCellValue;

        q.Enqueue(new Point(row, col));
        Visited[row, col] = true;

        while (q.Count > 0)
        {
            Point currentCell = q.Dequeue();
            counter++;

            currentCellValue = inMatrix[currentCell.row,currentCell.col];

            TryVisit(inMatrix, q, currentCell.row, currentCell.col + 1, currentCellValue);
            TryVisit(inMatrix, q, currentCell.row, currentCell.col - 1, currentCellValue);
            TryVisit(inMatrix, q, currentCell.row + 1, currentCell.col, currentCellValue);
            TryVisit(inMatrix, q, currentCell.row - 1, currentCell.col, currentCellValue);
        }

        return counter;
    }

    static int FindLongestSequence(int[,] inMatrix)
    {
        Visited = new bool[inMatrix.GetLength(0), inMatrix.GetLength(1)];
        int maxArea = 0;

        for (int row = 0; row < inMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < inMatrix.GetLength(1); col++) if (!Visited[row, col]) maxArea = Math.Max(BFS(inMatrix, row, col), maxArea);
        }

        return maxArea;
    }

    static void PrintMatrix(int[,] inMatrix, int rowSize, int colSize)
    {
        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++) Console.Write("{0} ", inMatrix[row, col]);
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int row, col, longestSequence = 1;

        row = int.Parse(Console.ReadLine());
        col = int.Parse(Console.ReadLine());

        int[,] matrix = new int[row,col];

        InputMatrix(matrix, row, col);
        PrintMatrix(matrix, row, col);

        longestSequence = FindLongestSequence(matrix);
        Console.WriteLine("The longest Sequence with neighbour elements consist {0} elements",longestSequence);
    }
}

