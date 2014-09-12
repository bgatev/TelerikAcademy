namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static int[] Distance;
        private static int?[] Previous;
        private static HashSet<int> allNodes = new HashSet<int>();

        public static void Dijkstra(int[,] graph, int source)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Distance[i] = int.MaxValue;
                Previous[i] = null;
                allNodes.Add(i);
            }

            Distance[source] = 0;

            while (allNodes.Count != 0)
            {
                int minNode = int.MaxValue;

                foreach (var node in allNodes)
                {
                    if (minNode > Distance[node]) minNode = node;
                }

                allNodes.Remove(minNode);

                if (minNode == int.MaxValue) break;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int potentialDistance = Distance[minNode] + graph[minNode, i];

                        if (potentialDistance < Distance[i])
                        {
                            Distance[i] = potentialDistance;
                            Previous[i] = minNode;
                        }
                    }
                }
            }
        }
        
        public static void Main()
        {
            int minDistance = int.MaxValue;

            string line = Console.ReadLine();
            string[] nmh = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            int N = int.Parse(nmh[0]);
            int M = int.Parse(nmh[1]);
            int H = int.Parse(nmh[2]);

            line = Console.ReadLine();
            string[] allHospitalsString = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<int> allHospitals = new HashSet<int>();

            for (int i = 0; i < H; i++) allHospitals.Add(int.Parse(allHospitalsString[i]));
            
            HashSet<int> allHouses = new HashSet<int>();
            for (int i = 1; i < N + 1; i++) if (!allHospitals.Contains(i)) allHouses.Add(i);

            int[,] routes = new int[N, N];
            for (int i = 1; i < M + 1; i++)
            {
                line = Console.ReadLine();
                string[] fsd = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int F = int.Parse(fsd[0]);
                int S = int.Parse(fsd[1]);
                int D = int.Parse(fsd[2]);

                routes[F - 1, S - 1] = D;
                routes[S - 1, F - 1] = D;
            }

            Distance = new int[N];
            Previous = new int?[N];           

            foreach (var item in allHospitals)
            {
                Dijkstra(routes, item - 1);

                var currentPath = 0;
                
                for (int i = 1; i < N + 1; i++)
                {
                    if (allHouses.Contains(i)) currentPath += Distance[i - 1];
                }

                if (minDistance > currentPath) minDistance = currentPath;
            }

            Console.WriteLine(minDistance);
        }
    }

}
