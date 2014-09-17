namespace Task_5
{
    using System;
    using System.Collections.Generic;

    public static class PancakeSorter
    {
        public static int Counter { get; set; }

        public static void Sort<T>(List<T> list) where T : IComparable
        {
            if (list.Count < 2) return;
            int i, a, max_num_pos;

            for (i = list.Count; i > 1; i--)
            {
                max_num_pos = 0;
                for (a = 0; a < i; a++)
                {
                    if (list[a].CompareTo(list[max_num_pos]) > 0) max_num_pos = a;
                }

                if (max_num_pos == i - 1) continue;
                if (max_num_pos > 0) Flip(list, list.Count, max_num_pos + 1);
                Flip(list, list.Count, i);
            }

            return;
        }

        private static void Flip<T>(List<T> list, int length, int num)
        {
            Counter++;
            for (int i = 0; i < --num; i++)
            {
                T swap = list[i];
                list[i] = list[num];
                list[num] = swap;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            int K = int.Parse(Console.ReadLine());

            string[] numbersString = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            List<int> numbers = new List<int>();
            for (int i = 0; i < N; i++) numbers.Add(int.Parse(numbersString[i]));

            PancakeSorter.Counter = 0;
            PancakeSorter.Sort<int>(numbers);


            Console.WriteLine(PancakeSorter.Counter);
        }
    }
}
