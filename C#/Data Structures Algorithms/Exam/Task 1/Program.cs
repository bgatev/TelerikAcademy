namespace Task_1
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            string[] xy = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int X = int.Parse(xy[0]);
            int Y = int.Parse(xy[1]);

            line = Console.ReadLine();
            string[] rc = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int R = int.Parse(rc[0]);
            int C = int.Parse(rc[1]);

            int[,] matrix = new int[R, C];
            bool[,] visited = new bool[R, C];
            for (int i = 0; i < R; i++)
            {
                line = Console.ReadLine();
                string[] cubes = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < C; j++)
                {
                    bool parsing = int.TryParse(cubes[j], out matrix[i, j]);
                    if (!parsing) matrix[i, j] = 0;
                    visited[i, j] = false;
                }   
            }

            int result = 1;
            int oldX = X;
            int oldY = Y;
            int currentX = X;
            int currentY = Y;

            /*while (true)
            {
                result += matrix[oldX, oldY];
                visited[oldX, oldY] = true;

                currentX += matrix[oldX, oldY];

                if (currentX >= R)
                {
                    currentX -= matrix[oldX, oldY];
                    currentY += matrix[oldX, oldY];
                }
                
                if (currentY >= C)
                {
                    currentY -= matrix[oldX, oldY];
                    currentX -= matrix[oldX, oldY];
                }

                if (currentX < 0)
                {
                    currentX += matrix[oldX, oldY];
                    currentY -= matrix[oldX, oldY];  
                }

                if (currentY < 0)
                {
                    currentY += matrix[oldX, oldY];
                    break;
                }

                oldX = currentX;
                oldY = currentY;
            }*/


            Console.WriteLine(result);
        }
    }
}
