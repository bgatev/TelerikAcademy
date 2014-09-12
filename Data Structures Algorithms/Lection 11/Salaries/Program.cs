namespace Salaries
{
    using System;
    using System.Collections.Generic;

    public class Salaries
    {
        static readonly IDictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
        static long[] employees;

        public static void Main()
        {
            int C = int.Parse(Console.ReadLine());
            employees = new long[C];

            for (int i = 0; i < C; i++)
            {
                string line = Console.ReadLine();

                adjacencyList[i] = new List<int>();

                for (int j = 0; j < C; j++) if (line[j] == 'Y') adjacencyList[i].Add(j);

                if (adjacencyList[i].Count == 0) employees[i] = 1;
            }

            Console.WriteLine(CalculateTotalSalary());
        }

        public static long CalculateTotalSalary()
        {
            long totalSalary = 0;

            for (int i = 0; i < employees.Length; i++) totalSalary += Calculate(i);

            return totalSalary;
        }

        public static long Calculate(int employeeId)
        {
            if (employees[employeeId] != 0) return employees[employeeId];

            foreach (var employee in adjacencyList[employeeId])
            {
                employees[employeeId] += Calculate(employee);
            }

            return employees[employeeId];
        }
    }
}
