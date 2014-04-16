using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task3
{
    static void MovePlayer(string moves, int stepNumber, ref int startRX, ref int startRY, ref int rotate)
    {
        //string lastMove = string.Empty;

        int currX = startRX, currY = startRY;

        if (moves[stepNumber] == 'L')
        {
            rotate -= 90;
            
        }
        else if (moves[stepNumber] == 'R')
        {
            rotate += 90;
            
        }
        else if (moves[stepNumber] == 'M')
        {
            if ((rotate % 360) == 0)
            {
                currY++;
            }
            else if ((rotate % 180) == 0) currY--;
            else if ((rotate % 270) == 0)
            {
                if ((rotate / 270) > 0) currX--;
                else currX++;
            }
            else if ((rotate % 90) == 0)
            {
                if ((rotate / 90) > 0) currX++;
                else currX--;
            }


            if ((currX < 0) || (currX > startRX))
            {
                if (currX < 0) startRX = 0;
                return;
            }
            
            if ((currY < 0) || (currY > startRY))
            {
                if (currY < 0) startRY = 0;
                return;
            }
                     
        }
        startRX = currX;
        startRY = currY;

        if ((rotate == 360) || (rotate == -360)) rotate = 0;    
    }
        
    static void Main()
    {
        int rotateR = 0, rotateB = 0;
        int distance = 0;

        string line = Console.ReadLine();
        string[] xyz = line.Split(' ');

        int X = int.Parse(xyz[0]), Y = int.Parse(xyz[1]), Z = int.Parse(xyz[2]);
        bool[,] visited = new bool[2 * Y + 2 * Z , X];

        int startRX = X / 2, startRY = Y / 2, startBX = X / 2, startBY = 3 * Y / 2 + Z;

        string RMoves = Console.ReadLine();
        string BMoves = Console.ReadLine();

        for (int i = 0; i < RMoves.Length; i++)
        {
            MovePlayer(RMoves, i, ref startRX, ref startRY, ref rotateR);
            if (RMoves[i] == 'M') distance++;

            if (visited[startRY, startRX])
            {
                Console.WriteLine("BLUE");
                Console.WriteLine(distance);
                break;  
            }
            else (visited[startRY, startRX]) = true;
            
            MovePlayer(BMoves, i, ref startBX, ref startBY, ref rotateB);
            if (visited[startBY, startBX])
            {
                Console.WriteLine("RED");
                Console.WriteLine(distance);
                break;
            }
            else (visited[startBY, startBX]) = true;
        }


    }
}

