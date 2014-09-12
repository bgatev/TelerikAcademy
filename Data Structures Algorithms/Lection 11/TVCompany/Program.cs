namespace TvCompany
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        static Tuple<int, int, int>[] paths;
        static ISet<int> houses;

        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            paths = new Tuple<int, int, int>[N];
            houses = new HashSet<int>();

            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                string[] nodeNodeDistance = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                paths[i] = new Tuple<int, int, int>(int.Parse(nodeNodeDistance[0]), int.Parse(nodeNodeDistance[1]), int.Parse(nodeNodeDistance[2]));
                houses.Add(int.Parse(nodeNodeDistance[0]));
                houses.Add(int.Parse(nodeNodeDistance[1]));
            }

            Console.WriteLine(string.Join(Environment.NewLine, paths.Select(a => string.Format("[{0} {1} -> {2}]", a.Item1, a.Item2, a.Item3))));

            var allTrees = RepresendEachNodeAsTree();
            double result = FindMinimalCost(allTrees);

            Console.WriteLine("\nMinimal cost for cable: " + result);
        }

        public static HashSet<ISet<int>> RepresendEachNodeAsTree()
        {
            var allTrees = new HashSet<ISet<int>>();

            foreach (var node in houses)
            {
                var tree = new HashSet<int>();

                tree.Add(node);
                allTrees.Add(tree);
            }

            return allTrees;
        }

        public static double FindMinimalCost(HashSet<ISet<int>> allTrees)
        {
            // Kruskal -> Sorting edges by their weight
            Array.Sort(paths, (a, b) => a.Item3.CompareTo(b.Item3));
            double result = 0;

            foreach (var path in paths)
            {
                var tree1 = allTrees.Where(tree => tree.Contains(path.Item1)).First();
                var tree2 = allTrees.Where(tree => tree.Contains(path.Item2)).First();
                
                // Elements are in same tree
                if (tree1.Equals(tree2)) continue;

                result += path.Item3;
                tree1.UnionWith(tree2);
                allTrees.Remove(tree2);

                if (allTrees.Count == 1) break;
            }

            return result;
        }
    }
}