using System;
using System.Linq;

class SpecialValue
{
    static string[] SplitString(string inString)
    {
        string[] temp = inString.Split(new string[] {", "},StringSplitOptions.RemoveEmptyEntries);
        int tempLength = 0;
        for (int i = 0; i < temp.Length; i++) if (temp[i] != "") tempLength++;

        string[] result = new string[tempLength];
        for (int i = 0, j = 0; i < temp.Length; i++) if (temp[i] != "") result[j++] = temp[i];

        return result;
    }

    static int FindSpecial(int[][] inLines, bool[][] visited)
    {
        int specialNum = 0, currentNum = 0;
                
        for (int col = 0; col < inLines[0].Length; col++)
        {
            int path = 1;

            if (inLines[0][col] < 0) currentNum = path + Math.Abs(inLines[0][col]);
            else
            {
                int row = 0, currentCol = inLines[row][col];
                
                visited[row][col] = true;
                do
                {
                    if (inLines.GetLength(0) == 1) row = -1;
                    path++;
                    if ((inLines[row + 1][currentCol] < 0))// || (visited[row + 1][currentCol]))
                    {
                        currentNum = path + Math.Abs(inLines[row + 1][currentCol]);
                        visited[row + 1][currentCol] = true;
                        break;
                    }
                    
                    //visited[row + 1][currentCol] = true;
                    currentCol = inLines[row + 1][currentCol];
                    row++;
                    if (row >= inLines.GetLength(0) - 1) row = 0;
                }
                while (true);
            }
            if (specialNum < currentNum) specialNum = currentNum;
        }

        return specialNum;
    }

    static void Main()
    {
        int N, specialNumber = 0;

        N = int.Parse(Console.ReadLine());

        string[] lineStr = new string[N];
        int[][] lines = new int[N][];
        bool[][] visited = new bool[N][];

        for (int i = 0; i < N; i++) lineStr[i] = Console.ReadLine();

        for (int i = 0; i < N; i++)
        {
            string[] temp = SplitString(lineStr[i]);
            lines[i] = new int[temp.Length];
            visited[i] = new bool[temp.Length];

            for (int j = 0; j < temp.Length; j++)
            {
                lines[i][j] = int.Parse(temp[j]);
                visited[i][j] = false;
            }
        }

        specialNumber = FindSpecial(lines, visited);

        Console.WriteLine(specialNumber);
    }
}

