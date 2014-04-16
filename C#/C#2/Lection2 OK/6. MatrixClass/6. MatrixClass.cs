//* Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, subtracting and multiplying of 
//matrices, indexer for accessing the matrix content and ToString().

using System;

class Matrix
{
    private int[,] matrix;                  //visible only in this class

    public int row
    {
        get
        { 
            return this.matrix.GetLength(0); 
        }
    }

    public int col
    {
        get
        {
            return this.matrix.GetLength(1);
        }
    }

    public Matrix(int row, int col)        //constructor
    {
        this.matrix = new int[row, col];
    }

    public int this[int row, int col]      //indexer
    {
        get
        {
            return this.matrix[row, col];
        }

        set
        {
            this.matrix[row, col] = value;
        }
    }

    public override string ToString()       //override buit-in method
    {
        string result = null;

        for (int row = 0; row < this.row; row++)
        {
            for (int col = 0; col < this.col; col++) result += matrix[row, col] + " ";
            result += Environment.NewLine;
        }

        return result;
    }
    
    static void InputMatrix(int[,] inMatrix, int rowNum, int colNum)
    {
        for (int row = 0; row < rowNum; row++)
        {
            for (int col = 0; col < colNum; col++)
            {
                inMatrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine();
    }

    static void SumMatrix(int[,] inMatrix1, int[,] inMatrix2, int[,] outMatrix, int sign)
    {
        int shorterXMatrix, longerXMatrix, shorterYMatrix, longerYMatrix;
        bool matrix1XIsLonger = false, matrix1YIsLonger = false;

        if (inMatrix1.GetLength(0) > inMatrix2.GetLength(0))
        {
            shorterXMatrix = inMatrix2.GetLength(0);
            longerXMatrix = inMatrix1.GetLength(0);
            matrix1XIsLonger = true;
        }
        else
        {
            shorterXMatrix = inMatrix1.GetLength(0);
            longerXMatrix = inMatrix2.GetLength(0);          
        }
        
        if (inMatrix1.GetLength(1) > inMatrix2.GetLength(1))
        {
            shorterYMatrix = inMatrix2.GetLength(1);
            longerYMatrix = inMatrix1.GetLength(1);
            matrix1YIsLonger = true;
        }
        else
        {
            shorterYMatrix = inMatrix1.GetLength(1);
            longerYMatrix = inMatrix2.GetLength(1);
        }


        for (int row = 0; row < shorterXMatrix; row++)
        {
            for (int col = 0; col < shorterYMatrix; col++) outMatrix[row, col] = inMatrix1[row, col] + sign * inMatrix2[row, col];         
        }

        if (matrix1YIsLonger)
        {
            for (int row = 0; row < shorterXMatrix; row++)
            {
                for (int col = shorterYMatrix; col < longerYMatrix; col++) outMatrix[row, col] = inMatrix1[row, col];
            }
        }
        else
        {
            for (int row = 0; row < shorterXMatrix; row++)
            {
                for (int col = shorterYMatrix; col < longerYMatrix; col++) outMatrix[row, col] = inMatrix2[row, col];
            }
        }

        if (matrix1XIsLonger)
        {
            for (int row = shorterXMatrix; row < longerXMatrix; row++)
            {
                for (int col = 0; col < shorterYMatrix; col++) outMatrix[row, col] = inMatrix1[row, col];
            }
        }
        else
        {
            for (int row = shorterXMatrix; row < longerXMatrix; row++)
            {
                for (int col = 0; col < shorterYMatrix; col++) outMatrix[row, col] = inMatrix2[row, col];
            }
        }

        for (int row = shorterXMatrix; row < longerXMatrix; row++)
        {
            for (int col = shorterYMatrix; col < longerYMatrix; col++) outMatrix[row, col] = 0;
        }
        Console.WriteLine();
    }

    static void MultiplyMatrix(int[,] inMatrix1, int[,] inMatrix2, int[,] outMatrix)
    {
        int shorterXMatrix, longerXMatrix, shorterYMatrix, longerYMatrix;
        bool matrix1XIsLonger = false, matrix1YIsLonger = false;

        if (inMatrix1.GetLength(0) > inMatrix2.GetLength(0))
        {
            shorterXMatrix = inMatrix2.GetLength(0);
            longerXMatrix = inMatrix1.GetLength(0);
            matrix1XIsLonger = true;
        }
        else
        {
            shorterXMatrix = inMatrix1.GetLength(0);
            longerXMatrix = inMatrix2.GetLength(0);
        }

        if (inMatrix1.GetLength(1) > inMatrix2.GetLength(1))
        {
            shorterYMatrix = inMatrix2.GetLength(1);
            longerYMatrix = inMatrix1.GetLength(1);
            matrix1YIsLonger = true;
        }
        else
        {
            shorterYMatrix = inMatrix1.GetLength(1);
            longerYMatrix = inMatrix2.GetLength(1);
        }


        for (int row = 0; row < shorterXMatrix; row++)
        {
            for (int col = 0; col < shorterYMatrix; col++) outMatrix[row, col] = inMatrix1[row, col] * inMatrix2[row, col];
        }

        if (matrix1YIsLonger)
        {
            for (int row = 0; row < shorterXMatrix; row++)
            {
                for (int col = shorterYMatrix; col < longerYMatrix; col++) outMatrix[row, col] = inMatrix1[row, col];
            }
        }
        else
        {
            for (int row = 0; row < shorterXMatrix; row++)
            {
                for (int col = shorterYMatrix; col < longerYMatrix; col++) outMatrix[row, col] = inMatrix2[row, col];
            }
        }

        if (matrix1XIsLonger)
        {
            for (int row = shorterXMatrix; row < longerXMatrix; row++)
            {
                for (int col = 0; col < shorterYMatrix; col++) outMatrix[row, col] = inMatrix1[row, col];
            }
        }
        else
        {
            for (int row = shorterXMatrix; row < longerXMatrix; row++)
            {
                for (int col = 0; col < shorterYMatrix; col++) outMatrix[row, col] = inMatrix2[row, col];
            }
        }

        for (int row = shorterXMatrix; row < longerXMatrix; row++)
        {
            for (int col = shorterYMatrix; col < longerYMatrix; col++) outMatrix[row, col] = 0;
        }
        Console.WriteLine();
    }

    static void PrintMatrix(int[,] inMatrix, int rowNum, int colNum)
    {
        for (int row = 0; row < rowNum; row++)
        {
            for (int col = 0; col < colNum; col++)
            {
                Console.Write("{0} ", inMatrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void PrintStringMatrix(string[,] inMatrix, int rowNum, int colNum)
    {
        for (int row = 0; row < rowNum; row++)
        {
            for (int col = 0; col < colNum; col++)
            {
                Console.Write("{0} ", inMatrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }


    static int ReturnElement(int[,] inMatrix, int row, int col)
    {
        if (row < (inMatrix.GetLength(0) - 1) && col < (inMatrix.GetLength(1))) return inMatrix[row, col];
        else return int.MinValue;
    }

    static void MatrixToString(int[,] inMatrix, string[,] outMatrix)
    {
        for (int row = 0; row < inMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < inMatrix.GetLength(1); col++) outMatrix[row, col] = Convert.ToString(inMatrix[row, col]);  
        }
    }

    static void Main()
    {
        int matrix1X, matrix1Y, matrix2X, matrix2Y, resultMatrixX, resultMatrixY;
        int matrixElement, returnIndexX, returnIndexY;

        matrix1X = int.Parse(Console.ReadLine());
        matrix1Y = int.Parse(Console.ReadLine());
        matrix2X = int.Parse(Console.ReadLine());
        matrix2Y = int.Parse(Console.ReadLine());
        
        returnIndexX = int.Parse(Console.ReadLine());
        returnIndexY = int.Parse(Console.ReadLine());

        resultMatrixX = Math.Max(matrix1X,matrix2X);
        resultMatrixY = Math.Max(matrix1Y, matrix2Y);

        int[,] numMatrix1 = new int[matrix1X, matrix1Y];
        int[,] numMatrix2 = new int[matrix2X, matrix2Y];
        int[,] resultMatrix = new int[resultMatrixX, resultMatrixY];
        string[,] stringMatrix = new string[resultMatrixX, resultMatrixY];

        InputMatrix(numMatrix1, matrix1X, matrix1Y);
        InputMatrix(numMatrix2, matrix2X, matrix2Y);

        SumMatrix(numMatrix1, numMatrix2, resultMatrix, 1);     // result is numMatrix1 + numMatrix2
        PrintMatrix(resultMatrix, resultMatrixX, resultMatrixY);

        SumMatrix(numMatrix1, numMatrix2, resultMatrix, -1);    // result is numMatrix1 - numMatrix2
        PrintMatrix(resultMatrix, resultMatrixX, resultMatrixY);

        MultiplyMatrix(numMatrix1, numMatrix2, resultMatrix);
        PrintMatrix(resultMatrix, resultMatrixX, resultMatrixY);

        matrixElement = ReturnElement(numMatrix1, returnIndexX, returnIndexY);
        Console.WriteLine(matrixElement);

        MatrixToString(numMatrix1, stringMatrix);
        PrintStringMatrix(stringMatrix, matrix1X, matrix1Y);
    }
}

