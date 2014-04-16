/*class TheBallGame

Variables:

- static int displayHeight - declares the height of the console
- public static int displayWidth - declares the width of the console
- int score – keeps the current score of the player

TheBallGame class consists of 6 methods as it follows:

- static void ConsoleInit()
Hides the cursor and sets the size, background and foreground colours of the console.

-	static void StartScreen()
Gives the user the ability to choose whether he wants to start a new game or exit.

static void PlayGame()
While the ball is not at the top row, floors are printed on the console and the speed increases gradually. If the ball happens to be exactly over the hole, the ball falls on the next floor. Otherwise, the player is expected to move the ball accordingly. If the speed exceeds 100000, it is set back to 1. "Game Over" is printed when the ball reaches the top floor.

-	static void SaveResult()
Takes player’s score and name as a parameter and saves it as a new text file. In case of exception, catches it and acts accordingly. 

-	static void PrintResults()
Reads top 5 high scores from the text file and prints them on the console in descending order and then by names. Handles possible exceptions. 
  
- static void Main()
Sets the console and prints the start screen.*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;


class TheBallGame
{
    public static int displayHeight = 50;
    public static int displayWidth = 50;
    public static int score = 0;
    public static int coeficient = 10;
    public static int level = 1;


    static void ConsoleInit()
    {
        Console.CursorVisible = false;
        Console.WindowHeight = displayHeight;
        Console.WindowWidth = displayWidth;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;

        //colors
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void StartScreen()
    {
        string start = "Start";
        string exit = "Exit";
        char pointer = '*';

        int startXposition = displayWidth / 2 - 3;
        int pointerXposition = startXposition - 3;
        int Yposition = displayHeight / 2 - 1;

        Console.SetCursorPosition(startXposition, Yposition);
        Console.WriteLine(start);
        Console.SetCursorPosition(startXposition, Yposition + 2);
        Console.WriteLine(exit);
        Console.SetCursorPosition(pointerXposition, Yposition);
        Console.WriteLine(pointer);
        
        bool startGame = true;
        ConsoleKeyInfo pressedKey;
        do
        {
            pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                Console.SetCursorPosition(pointerXposition, Yposition);
                Console.WriteLine(pointer);
                Console.SetCursorPosition(pointerXposition, Yposition + 2);
                Console.WriteLine(' ');
                startGame = true;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                Console.SetCursorPosition(pointerXposition, Yposition);
                Console.WriteLine(' ');
                Console.SetCursorPosition(pointerXposition, Yposition + 2);
                Console.WriteLine(pointer);
                startGame = false;
            }
            else if (pressedKey.Key == ConsoleKey.Enter)
            {
                if (startGame) PlayGame();
                else Environment.Exit(0);
            }
        }
        while (Console.KeyAvailable || pressedKey.Key != ConsoleKey.Enter);
    }

    
    static void PlayGame()
    {
        Console.Clear();

        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Interval = 30000;
        timer.Elapsed += new ElapsedEventHandler(IncreaseSpeed);
        timer.Start();

        string row = string.Empty;
        double sleepTime = 200;
        int speed = 10;
        score = 0;
        level = 1;
        coeficient = 10;

        Ball ball = new Ball();
        GameOver gameEnd = new GameOver();

        ball.Init();
        Floor[] floors = new Floor[displayHeight / 2];
        for (int i = floors.Length - 1; i > -1; i--)
        {
            floors[i] = new Floor("");
            floors[i].YPos = i * 2;
        }

        do
        {

            //this magic number drives floors to move 22 times slowly than ball /execute floors moves 1 time per 22 cycles/
            //if you want to speed-up game decrease magic number from 22 to smaller number
            //also you can use any variable to change speed dynamically
            if (speed % 10 == 0)
            {
                floors[displayHeight / 2 - 1] = new Floor(" ");
                for (int i = 0; i < displayHeight / 2 - 1; i++)
                {
                    floors[i] = floors[i + 1];
                    floors[i].Move();           //move & draw
                }

                ball.DeleteBall(ball.X, ball.Y);
                ball.Y -= 2;
                //ball.setY(ball.Y - 2);
                ball.PrintAtPosition(ball.X, ball.Y);
            }

            speed++;
            if (speed > 100000) speed = 1;
            Thread.Sleep((int)sleepTime - coeficient);

            if ((ball.X == floors[ball.Y / 2].HolePos || ball.X == floors[ball.Y / 2].HolePos + 1 ||
                ball.X == floors[ball.Y / 2].HolePos + 2) || (floors[ball.Y / 2].HolePos == -1))
            {
                ball.DeleteBall(ball.X, ball.Y);
                ball.Y += 2;
                //ball.setY(ball.Y + 2);
                ball.PrintAtPosition(ball.X, ball.Y);
                score += coeficient;
            }

            ball.MoveBall();

            Console.SetCursorPosition(1, 1);
            Console.Write("Score: {0}", score);
            
            Console.SetCursorPosition(displayWidth - 10, 1);
            Console.Write("Level: {0}", level);
            
        } while (ball.Y > 1);

        timer.Stop();
        
        Console.Clear();
        gameEnd.PrintGameOver();
        Thread.Sleep(3000);

        //results
        Console.Clear();

        Console.SetCursorPosition(displayWidth / 2 - 12, displayHeight / 2 - 10);
        Console.Write("Please enter your name: ");
        Console.SetCursorPosition(displayWidth / 2 - 5, displayHeight / 2 - 8);
        string name = Console.ReadLine();
        Console.Clear();
        SaveResult(score,name);

        
        PrintResults(score);
        Thread.Sleep(15000);
        Console.Clear();

        StartScreen();
    }

    private static void IncreaseSpeed(object source, ElapsedEventArgs e)
    {
        coeficient += 10;
        level++;
    }

    static void SaveResult(int score, string name)
    {
        const string FilePath = @"..\..\";
        const string FileName = @"results.txt";
        
        try
        {
            using (StreamWriter writer = new StreamWriter(FilePath + FileName, true))
            {
                writer.WriteLine("{0} - {1}", score, name);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have write access to this file");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Please check your path - directory not found");
        }
        catch (IOException exc)
        {
            Console.WriteLine(exc.Message);
        }
        
    }

    static void PrintResults(int score)
    {
        const string FilePath = @"..\..\";
        const string FileName = @"results.txt";
       
        List<Results> allResults = new List<Results>();
        
        GameOver bestGame = new GameOver();

        try
        {
            using (StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251")))
            {
                
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] singleLine = line.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                    Results currentResult = new Results();

                    currentResult.Score = int.Parse(singleLine[0]);
                    currentResult.Name = singleLine[1];
                    allResults.Add(currentResult);
                    line = reader.ReadLine();
                }
                //sort in descending order
                var sortedResult = allResults.OrderByDescending(sc => sc.Score).ThenBy(sc => sc.Name);
               
                int place = 1;
                var firstResult = sortedResult.First();
                if ((place == 1) && (score >= firstResult.Score))
                {
                    bestGame.PrintBestPlayer();
                    Thread.Sleep(5000);
                    Console.Clear();
                }

                Console.SetCursorPosition(displayWidth / 2 - 9, displayHeight / 2 - 10);
                Console.WriteLine("Your score: {0}", score);
                Console.SetCursorPosition(displayWidth / 2 - 7, displayHeight / 2 - 7);
                Console.WriteLine("High scores:");

                int setHeight = 5;
                foreach (var singleResult in sortedResult)
                {                 
                    Console.SetCursorPosition(displayWidth / 2 - 12, displayHeight / 2 - setHeight);
                    Console.WriteLine("{0}. {1} - {2} points", place, singleResult.Name, singleResult.Score);
                    if (place >= 5) break;
                    place++;
                    setHeight--;
                }
                
            }
        }
        catch (DirectoryNotFoundException exc)
        {
            Console.WriteLine("Directory {0} is not found.", exc.Message);
        }
        catch (FileNotFoundException exc)
        {
            Console.WriteLine("File {0} is not found.", exc.FileName);
        }
        catch (NullReferenceException exc)
        {
            Console.WriteLine(exc.Message);
        }
        
    }

    static void Main()
    {
        ConsoleInit();
       
        StartScreen();
    }
}

