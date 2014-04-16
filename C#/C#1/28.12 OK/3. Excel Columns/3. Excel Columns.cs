using System;

class ExcelColumns
{
    static void Main()
    {
        int N;
        double result = 0;

        N = int.Parse(Console.ReadLine());
        char[] colIndex = new char[N];
        int[] colNumIndex = new int[N];

        for (int i = N-1; i >= 0; i--)
        {
            colIndex[i] = char.Parse(Console.ReadLine());
            colNumIndex[i] = (Convert.ToInt32(colIndex[i]) - 0x40);

            result += Math.Pow(26,i)*colNumIndex[i];


        }

         
        Console.WriteLine(result);
    }
}

