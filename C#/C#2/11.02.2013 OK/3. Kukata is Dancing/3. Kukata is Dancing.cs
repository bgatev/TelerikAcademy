using System;
using System.Linq;

class KukataisDancing
{
    static string Move(string inLine)
    {
        string lastMove = string.Empty;
        int dirL = 0, dirR = 0, currXPos = 1, currYPos = 1, rotate = 0;

        for (int i = 0; i < inLine.Length; i++)
        {
            if (inLine[i] == 'L')
            {
                rotate -= 90;
                dirL = -1;
                dirR = 0;
            }
            else if (inLine[i] == 'R')
            {
                rotate += 90;
                dirR = 1;
                dirL = 0;
            }
            else if (inLine[i] == 'W')
            {
                if ((rotate % 360) == 0) currYPos++;
                else if ((rotate % 180) == 0) currYPos--;
                else if ((rotate % 270) == 0)
                {
                    if ((rotate / 270) > 0) currXPos--;
                    else currXPos++;
                }
                else if ((rotate % 90) == 0)
                {
                    if ((rotate / 90) > 0) currXPos++;
                    else currXPos--;
                }
                
                if (currXPos > 2) currXPos = 0;
                else if (currXPos < 0) currXPos = 2;

                if (currYPos > 2) currYPos = 0;
                else if (currYPos < 0) currYPos = 2;
            }
            if ((rotate == 360) || (rotate == -360)) rotate = 0;
            
        }

        lastMove = currXPos.ToString() + currYPos.ToString();
        return lastMove;
    }
    
    static void Main()
    {
        int N;       
        string[,] cube = new string[3, 3] {{ "RED",  "BLUE",  "RED"}, 
                                           {"BLUE", "GREEN", "BLUE"}, 
                                           { "RED",  "BLUE",  "RED"}};

        N = int.Parse(Console.ReadLine());
        string[] line = new string[N];

        for (int i = 0; i < N; i++) line[i] = Console.ReadLine();

        for (int i = 0; i < N; i++)
        {
            string result = Move(line[i]);
            Console.WriteLine(cube[Convert.ToInt32(result[0]) - '0', Convert.ToInt32(result[1]) - '0']);
        }
    }
}

