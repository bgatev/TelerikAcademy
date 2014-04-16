//Write a program that reads a text file containing a square matrix of numbers and finds in the matrix an area of size 2 x 2 with a 
//maximal sum of its elements. The first line in the input file contains the size of matrix N. Each of the next N lines contain N numbers 
//separated by space. The output should be a single number in a separate text file. Example:
// 4
// 2 3 3 4
// 0 2 3 4			17
// 3 7 1 2
// 4 3 3 2

using System;
using System.IO;
using System.Linq;
using System.Text;

class ReadMatrix1
{
    static void InputMatrix(string inRow, int rowNum, int[,] inMatrix)
    {
        string[] temp = new string[inMatrix.GetLength(0)];

        temp = inRow.Split(' ');
        for (int col = 0; col < inMatrix.GetLength(0); col++) inMatrix[rowNum, col] = int.Parse(temp[col]);
    }

    static int FindSquareSum(int[,] inMatrix, int startRow, int startCol, int sizeRow, int sizeCol)
    {
        int sum = 0;

        for (int row = startRow; row < (startRow + sizeRow); row++)
        {
            for (int col = startCol; col < (startCol + sizeCol); col++) sum += inMatrix[row, col];
        }
        
        return sum;
    }

    static int FindSquareMaxSum(int[,] inMatrix, int sizeRow, int sizeCol)
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
    
    static void Main()
    {
        const string FilePath = @"..\..\";
        const string FileName = @"test.txt";
        const string FilePathResult = @"..\..\";
        const string FileNameResult = @"output.txt";

        string matrixRow = string.Empty;
        int matrixSize = 0, rowNumber = 0, squareMaxSum = 0, squareRowSize = 2, squareColSize = 2;
        
        try
        {
            StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251"));
            StreamWriter writer = new StreamWriter(FilePathResult + FileNameResult, false, Encoding.GetEncoding("windows-1251"));

            matrixSize = int.Parse(reader.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            try
            {
                matrixRow = reader.ReadLine();
                while (matrixRow != null)
                {
                    InputMatrix(matrixRow, rowNumber, matrix);

                    matrixRow = reader.ReadLine();
                    rowNumber++;
                }
            }
            finally
            {
                squareMaxSum = FindSquareMaxSum(matrix, squareRowSize, squareColSize);

                writer.WriteLine("Max Sum of square with size {0}x{1} is {2}", squareRowSize, squareColSize, squareMaxSum);
                Console.WriteLine("Max Sum of square with size {0}x{1} is {2}", squareRowSize, squareColSize, squareMaxSum);

                reader.Close();
                writer.Close();
                Console.WriteLine("File is written");
            }
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid Argument - Your variables is NULL");
        }

        catch (ArgumentException)
        {
            Console.WriteLine("Invalid Argument - Please see your variables");
        }

        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid Path - Please check your full path");
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Invalid Filename - File not found");
        }

        catch (IOException)
        {
            Console.WriteLine("Please check your full path and filename");
        }

        catch
        {
            Console.WriteLine("You are totally fucked");
        }
    }
}

