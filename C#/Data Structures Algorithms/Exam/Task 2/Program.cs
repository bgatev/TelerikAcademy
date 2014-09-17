namespace Task_2
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        static int K;
        static int L;
        static int N;
        static char[] skirts = new char[]{'0','1','2','b','a','c','a'};
        static int[] arr;
        static StringBuilder result;
        static HashSet<string> allComb;

        public static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= 2)
            {
                int counter = 0;
                for (int i = 0; i < N; i++)
                {
                    if (skirts[arr[i]] >= 'a' && skirts[arr[i]] <= 'z') counter++;
                        
                }

                if (counter == N) PrintVariations();
            }
            else
            {
                for (int i = start; i < L; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        public static void Main()
        {
            K = 3;// int.Parse(Console.ReadLine());
            //skirts = Console.ReadLine().ToCharArray();
            L = skirts.Length;
            N = 2;// int.Parse(Console.ReadLine());
            result = new StringBuilder();
            allComb = new HashSet<string>();

            arr = new int[N];
            GenerateCombinationsNoRepetitions(0, 0);

            Console.WriteLine(result.ToString());
        }

        public static void PrintVariations()
        {
            for (int i = 0; i < K; i++)
            {
                
            }
            string currentSet = string.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                currentSet += skirts[arr[i]] + "-";
            }

            currentSet = currentSet.Substring(0, currentSet.Length - 1);
            allComb.Add(currentSet);
            result.AppendLine(currentSet);
        }
    }
}
