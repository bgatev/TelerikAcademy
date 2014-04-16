/*class GameOver

The GameOver class consists of 2 methods as it follows:

- public void PrintBestPlayer()
Creates two arrays. One to print the best player and another to print his result.

- public void PrintGameOver()
Creates two arrays to print that the game is over.

class Results - Object with properties Score and Name - used for file Read/Write */

using System;
using System.Linq;

class Results
{
    public int Score { get; set; }
    public string Name { get; set; }
}

class GameOver
{
    public void PrintBestPlayer()
    {
        string[] bestPlayer = new string[14];
        char[,] bestScore = new char[14, TheBallGame.displayWidth];

        bestPlayer[0] =  "        BBBBB     EEEEE      SSSS   TTTTTTT       ";
        bestPlayer[1] =  "        B   B     E         S       T  T  T       ";
        bestPlayer[2] =  "        B  BB     E          SS        T          ";
        bestPlayer[3] =  "        BBB       EEEEE        SS      T          ";
        bestPlayer[4] =  "        B  BB     E             S      T          ";
        bestPlayer[5] =  "        B   B     E             S      T          ";
        bestPlayer[6] =  "        BBBBB     EEEEE     SSSS       T          ";
        bestPlayer[7] =  " PPPPP    L         A     Y     Y   EEEEE   RRRRR ";
        bestPlayer[8] =  " P   P    L        A A     Y   Y    E       R   R ";
        bestPlayer[9] =  " P   P    L       A   A     Y Y     E       R   R ";
        bestPlayer[10] = " PPPP     L       A   A      Y      EEEEE   RRR   ";
        bestPlayer[11] = " P        L       AAAAA      Y      E       R  R  ";
        bestPlayer[12] = " P        L       A   A      Y      E       R   R ";
        bestPlayer[13] = " P        LLLLL   A   A      Y      EEEEE   R   R ";

        for (int i = 0; i < 5; i++) Console.WriteLine();
        for (int row = 0; row < 14; row++)
        {
            for (int col = 0; col < bestPlayer[row].Length; col++)
            {
                bestScore[row, col] = bestPlayer[row][col];
                Console.Write(bestScore[row, col]);
            }
            Console.WriteLine();
            if (row == 6) Console.WriteLine();
        }

    }
    
    public void PrintGameOver()
    {   
        string[] game = new string[6];
        string[] over = new string[6];
        
        game[0] = "  GG           AA        MM     MM       EEEEEEEE";
        game[1] = "GG  GG       AA  AA     MM MM  MM MM     EE      ";
        game[2] = "GG           AA  AA     MM  MMMM  MM     EE      ";
        game[3] = "GG GGG       AAAAAA     MM   MM   MM     EEEEEEE ";
        game[4] = "GG  GG       AA  AA     MM        MM     EE      ";
        game[5] = "  GG         AA  AA     MM        MM     EEEEEEEE";

        over[0] = "  OO         VV  VV      EEEEEEEE       RRRRR  ";
        over[1] = "OO  OO       VV  VV      EE             RR   RR";
        over[2] = "OO  OO       VV  VV      EE             RR   RR";
        over[3] = "OO  OO       VV  VV      EEEEEEE        RRRRRRR";
        over[4] = "OO  OO       VV  VV      EE             RR  RR ";
        over[5] = "  OO           VV        EEEEEEEE       RR   RR";

        for (int i = 0; i < 15; i++) Console.WriteLine();
        for (int i = 0; i < game.Length; i++) Console.WriteLine(game[i]);
        Console.WriteLine();
        for (int i = 0; i < over.Length; i++) Console.WriteLine(over[i]);        
    }
}

