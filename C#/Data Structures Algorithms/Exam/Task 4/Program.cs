namespace Task_4
{
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        public static void SelSort(IList<int> collection)
        {
            if (collection == null) throw new ArgumentNullException("Collection cannot be null.");

            int swapIndex = 0;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                swapIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[swapIndex].CompareTo(collection[j]) > 0) swapIndex = j;
                }

                Swap(collection, i, swapIndex);
            }
        }

        private static void Swap(IList<int> collection, int i, int swapIndex)
        {
            int swap = collection[i];
            collection[i] = collection[swapIndex];
            collection[swapIndex] = swap;
        }

        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            List<int> towns = new List<int>();
            List<int> temp = new List<int>();

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                string[] townsString = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                towns.Add(int.Parse(townsString[0]));
                temp.Add(int.Parse(townsString[0]));
            }

            SelSort(temp);

            int result = 0;
            for (int i = 0; i < N - 1; i++)
            {
                if (towns[i + 1] > towns[i])
                {
                    result++;
                }
                else
                {
                    if (towns[i + 1] < towns[i]) result++;
                    else break;
                }
                if (result == 999) result++;
            }

            for (int z = 0; z < towns.Count; z++)
            {
                int count = 1;
                var max = temp[towns.Count - 1];
                var maxIndex = towns.FindIndex(i => i == max) - z;
                if (maxIndex < 0) continue;
                var maxElement = towns[0];
                for (int i = 1; i < maxIndex; i++)
                {
                    if (towns[i] > maxElement)
                    {
                        count++;
                        maxElement = towns[i];
                    }
                }

                for (int i = maxIndex; i < towns.Count; i++)
                {
                    if (towns[i] < maxElement)
                    {
                        count++;
                        maxElement = towns[i];
                    }
                }

                if (count > result) result = count;
            }

            Console.WriteLine(result);
        }
    }
}
