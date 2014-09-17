﻿namespace Minimum_Edit_Distance
{
    using System;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine(MED("developer", "enveloped"));
            Console.WriteLine(MED("developer", "eveloper"));
            Console.WriteLine(MED("eveloper", "enveloper"));
            Console.WriteLine(MED("enveloper", "enveloped"));
        }

        public static double MED(string firstValue, string secondValue)
        {
            double[,] matrix = new double[firstValue.Length + 1, secondValue.Length + 1];

            var costOfReplace = 1.0;
            var costOfDelete = 0.9;
            var costOfInsert = 0.8;

            // Step 1
            if (firstValue.Length == 0) return secondValue.Length * costOfInsert;
            if (secondValue.Length == 0) return firstValue.Length * costOfDelete;

            // Step 2
            for (int row = 0; row <= firstValue.Length; row++) matrix[row, 0] = row * costOfDelete;
            for (int col = 0; col <= secondValue.Length; col++) matrix[0, col] = col * costOfInsert;

            // Step 3
            for (int row = 1; row <= firstValue.Length; row++)
            {
                //Step 4
                for (int col = 1; col <= secondValue.Length; col++)
                {
                    // Step 5
                    if (secondValue[col - 1] == firstValue[row - 1]) matrix[row, col] = matrix[row - 1, col - 1];

                    // Step 6
                    else
                    {
                        var deletion = matrix[row - 1, col] + costOfDelete;
                        var insertion = matrix[row, col - 1] + costOfInsert;
                        var replace = matrix[row - 1, col - 1] + costOfReplace;

                        matrix[row, col] = Math.Min(Math.Min(deletion, insertion), replace);
                    }
                }
            }

            // Step 7
            return matrix[firstValue.Length, secondValue.Length];
        }
    }
}
