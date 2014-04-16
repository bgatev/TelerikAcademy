using System;
using System.Linq;

class Problem5AcademyTasks
{
    static void Main(string[] args)
    {
        string line = Console.ReadLine();
        int variety = int.Parse(Console.ReadLine());

        string[] numberStr = line.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);

        int[] pleasantness = new int[numberStr.Length];
        int minProblems = pleasantness.Length;

        for (int i = 0; i < minProblems; i++) pleasantness[i] = int.Parse(numberStr[i]); 

        for (int i = 0; i < pleasantness.Length; i++)   //ByAuthors
        {
            for (int j = i + 1; j < pleasantness.Length; j++)
            {
                int diff = Math.Abs(pleasantness[i] - pleasantness[j]);
                if (diff < variety) continue;
                
                int act = (i + 3) / 2;
                act += (j - i + 1) / 2;

                minProblems = Math.Min(minProblems, act);
            }
        }

        Console.WriteLine(minProblems);
    }
}

