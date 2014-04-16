//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements 
//located on the same line, column or diagonal. Write a program that finds the first longest sequence of equal strings in the matrix.
// aba aba aba bar bar ara bac bac
// qwe wer wer wer qaz rar rar faq
// zor zor zor zor var var faq var
// how zor how zor hem var var var
// zor how zor got zor var nit nit
// how zor min zor get zor nor aba

using System;

class MatrixSequence
{
    static void InputMatrix(string[,] inMatrix, int rowNum, int colNum)
    {
        for (int row = 0; row < rowNum; row++)
        {
            for (int col = 0; col < colNum; col++)
            {
                inMatrix[row, col] = Console.ReadLine();
            }
        }
        Console.WriteLine();
    }

    static string CheckByLine(string[,] inMatrix, int rowNum, int colNum)
    {
        int lineLenght = 1, maxLineLenght = 0;
        string indexAndLenght = string.Empty, rowcolIndex = string.Empty;

        for (int row = 0; row < rowNum; row++)
        {
            for (int col = 0; col < colNum - 1; col++)
            {
                if (inMatrix[row, col] == inMatrix[row, col + 1]) lineLenght++;
                else
                {
                    if (lineLenght > maxLineLenght)
                    {
                        maxLineLenght = lineLenght;
                        rowcolIndex = Convert.ToString(row) + '*' + Convert.ToString(col - maxLineLenght + 1);
                    }
                    lineLenght = 1;
                }
                if (col == colNum - 2)
                {
                    if (lineLenght > maxLineLenght)
                    {
                        maxLineLenght = lineLenght;
                        rowcolIndex = Convert.ToString(row) + '*' + Convert.ToString(col - maxLineLenght + 2);
                    }
                }
            }
            lineLenght = 1;
        }

        indexAndLenght = Convert.ToString(maxLineLenght) + '-' + rowcolIndex;     //Length and start index
        return indexAndLenght;
    }

    static string CheckByColumn(string[,] inMatrix, int rowNum, int colNum)
    {
        int colLenght = 1, maxColLenght = 0;
        string indexAndLenght = string.Empty, rowcolIndex = string.Empty;

        for (int col = 0; col < colNum; col++)
        {
            for (int row = 0; row < rowNum - 1; row++)
            {
                if (inMatrix[row, col] == inMatrix[row + 1, col]) colLenght++;
                else
                {
                    if (colLenght > maxColLenght)
                    {
                        maxColLenght = colLenght;
                        rowcolIndex = Convert.ToString(row - maxColLenght + 1) + '*' + Convert.ToString(col);
                    }
                    colLenght = 1;
                }
                if (row == rowNum - 2)
                {
                    if (colLenght > maxColLenght)
                    {
                        maxColLenght = colLenght;
                        rowcolIndex = Convert.ToString(row - maxColLenght + 2) + '*' + Convert.ToString(col);
                    }
                }
            }
            colLenght = 1;
        }

        indexAndLenght = Convert.ToString(maxColLenght) + '-' + rowcolIndex;     //Length and start index
        return indexAndLenght;
    }

    static string CheckByDiagLR(string[,] inMatrix, int rowNum, int colNum)
    {
        int diagLRLenght = 1, maxDiagLRLenght = 0;
        string indexAndLenght = string.Empty, rowcolIndex = string.Empty, tempRowColIndex = string.Empty;

        int row = rowNum - 2, col = 0, counter = 0;

        do
        {
            counter++;

            if (inMatrix[row, col] == inMatrix[row + 1, col + 1]) diagLRLenght++;
            else
            {
                tempRowColIndex = Convert.ToString(row - diagLRLenght + 1) + '*' + Convert.ToString(col - diagLRLenght + 1);
                if (diagLRLenght > maxDiagLRLenght)
                {
                    maxDiagLRLenght = diagLRLenght;
                    rowcolIndex = tempRowColIndex;
                }
                diagLRLenght = 1;
            }
            row++;
            col++;

            if (col == colNum - 1)          
            {
                tempRowColIndex = Convert.ToString(row - diagLRLenght + 1) + '*' + Convert.ToString(col - diagLRLenght + 1);
                row = 0;
                col -= (counter - 1);
                if (diagLRLenght > maxDiagLRLenght)
                {
                    maxDiagLRLenght = diagLRLenght;
                    rowcolIndex = tempRowColIndex;
                }
                counter = 0;
                diagLRLenght = 1;
            }
            
            if (row == rowNum - 1)
            {
                tempRowColIndex = Convert.ToString(row - diagLRLenght + 1) + '*' + Convert.ToString(col - diagLRLenght + 1);
                if (counter == rowNum - 1)
                {
                    row = 0;
                    col -= (counter - 1);
                }
                else
                {
                    row -= (counter + 1);
                    col -= counter;
                }
                if (diagLRLenght > maxDiagLRLenght)
                {
                    maxDiagLRLenght = diagLRLenght;
                    rowcolIndex = tempRowColIndex;
                }
                counter = 0;
                diagLRLenght = 1;
            }

        } while (!((col == colNum - 1) && (row == 0)));

        indexAndLenght = Convert.ToString(maxDiagLRLenght) + '-' + rowcolIndex;     //Length and start index
        return indexAndLenght;
    }

    static string CheckByDiagRL(string[,] inMatrix, int rowNum, int colNum)
    {
        int diagRLLenght = 1, maxDiagRLLenght = 0;
        string indexAndLenght = string.Empty, rowcolIndex = string.Empty, tempRowColIndex = string.Empty;

        int row = 0, col = 1, counter = 0;

        do
        {
            counter++;

            if (inMatrix[row, col] == inMatrix[row + 1, col - 1]) diagRLLenght++;
            else
            {
                tempRowColIndex = Convert.ToString(row - diagRLLenght + 1) + '*' + Convert.ToString(col + diagRLLenght - 1);
                if (diagRLLenght > maxDiagRLLenght)
                {
                    maxDiagRLLenght = diagRLLenght;
                    rowcolIndex = tempRowColIndex;
                }
                diagRLLenght = 1;
            }
            if (row < rowNum) row++;
            col--;

            if (col == colNum - 1)
            {
                tempRowColIndex = Convert.ToString(row - diagRLLenght + 1) + '*' + Convert.ToString(col + diagRLLenght - 1);
                row -= (counter - 1);
                col += counter;
                if (diagRLLenght > maxDiagRLLenght)
                {
                    maxDiagRLLenght = diagRLLenght;
                    rowcolIndex = tempRowColIndex;
                }
                counter = 0;
                diagRLLenght = 1;
            }

            if (row == rowNum - 1)
            {
                tempRowColIndex = Convert.ToString(row - diagRLLenght + 1) + '*' + Convert.ToString(col + diagRLLenght - 1);
                if (counter == rowNum - 1)
                {
                    if (col > (colNum - 2 - counter))
                    {
                        row -= (counter - 1);
                        col += counter;
                    }
                    else
                    {
                        row = 0;
                        col += (counter + 1);
                    }
                }
                else
                {
                    row -= (counter - 1);
                    col += counter;
                }
                if (diagRLLenght > maxDiagRLLenght)
                {
                    maxDiagRLLenght = diagRLLenght;
                    rowcolIndex = tempRowColIndex;
                }
                counter = 0;
                diagRLLenght = 1;
            }

            if (col == 0)
            {
                tempRowColIndex = Convert.ToString(row - diagRLLenght + 1) + '*' + Convert.ToString(col + diagRLLenght - 1);
                row = 0;
                col += (counter + 1);
                if (diagRLLenght > maxDiagRLLenght)
                {
                    maxDiagRLLenght = diagRLLenght;
                    rowcolIndex = tempRowColIndex;
                }
                counter = 0;
                diagRLLenght = 1;
            }

        } while (!((col == colNum - 1) && (row == rowNum - 1)));

        indexAndLenght = Convert.ToString(maxDiagRLLenght) + '-' + rowcolIndex;     //Length and start index
        return indexAndLenght;
    }

    static void PrintMatrix(string[,] inMatrix, int rowNum, int colNum)
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

    static int FindLenght(string inString)
    {
        int result = 0;

        for (int i = 0, counter = 0; i < inString.Length; i++)
        {
            if (inString[i] != '-') counter++;
            else 
            {
                for (int j = counter, k = 1; j > 0; j--, k *= 10) result += (inString[j - 1] - '0') * k;
			    break;
            }
        }

        return result;
    }

    static void FindLongestSequence(string lineChecked, string colChecked, string diagLRChecked, string diagRLChecked)
    {
        int firstLongestSequenceLenght;
        string firstLongestSequence = string.Empty;

        if ( (FindLenght(lineChecked) >= FindLenght(colChecked)) && (FindLenght(lineChecked) >= FindLenght(diagLRChecked)) && (FindLenght(lineChecked) >= FindLenght(diagRLChecked))) 
            Console.WriteLine("First Longest Sequence is with {0} Elements", FindLenght(lineChecked));
        else if ((FindLenght(colChecked) >= FindLenght(lineChecked)) && (FindLenght(colChecked) >= FindLenght(diagLRChecked)) && (FindLenght(colChecked) >= FindLenght(diagRLChecked)))
            Console.WriteLine("First Longest Sequence is with {0} Elements", FindLenght(colChecked));
        else if ((FindLenght(diagLRChecked) >= FindLenght(lineChecked)) && (FindLenght(diagLRChecked) >= FindLenght(colChecked)) && (FindLenght(diagLRChecked) >= FindLenght(diagRLChecked)))
            Console.WriteLine("First Longest Sequence is with {0} Elements", FindLenght(diagLRChecked));
        else if ((FindLenght(diagRLChecked) >= FindLenght(lineChecked)) && (FindLenght(diagRLChecked) >= FindLenght(colChecked)) && (FindLenght(diagRLChecked) >= FindLenght(diagLRChecked)))
            Console.WriteLine("First Longest Sequence is with {0} Elements", FindLenght(diagRLChecked));
    }

    static void Main()
    {
        int N, M;
        string lineChecked = string.Empty, colChecked = string.Empty, diagLRChecked = string.Empty, diagRLChecked = string.Empty;
                
        N = int.Parse(Console.ReadLine());
        M = int.Parse(Console.ReadLine());

        string[,] matrix = new string[N, M];

        InputMatrix(matrix, N, M);

        lineChecked = CheckByLine(matrix, N, M);
        colChecked = CheckByColumn(matrix, N, M);
        diagLRChecked = CheckByDiagLR(matrix, N, M);
        diagRLChecked = CheckByDiagRL(matrix, N, M);
        
        PrintMatrix(matrix, N, M);
                
        Console.WriteLine("Line Result: {0}",lineChecked);
        Console.WriteLine("Column Result: {0}", colChecked);
        Console.WriteLine("Diag Left to Right Result: {0}", diagLRChecked);
        Console.WriteLine("Diag Right to Left Result: {0}", diagRLChecked);

        FindLongestSequence(lineChecked, colChecked, diagLRChecked, diagRLChecked);
        
    }
}

