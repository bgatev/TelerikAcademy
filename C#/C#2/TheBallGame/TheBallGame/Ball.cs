/*class Ball

Variables:

int x - declares the ball position on the x-axis
int y - declares the ball position on the y-axis
char ballSymbol - declares the symbol used to represent the ball 

The Ball class consists of 6 methods as it follows:

- public Ball()
Uses variables x, y to specify the position of the ball and the ballSymbol variable for the ball itself.

- public void Init() 
Sets the default position of the ball using x and y axes.

- public void PrintAtPosition(int xPos, int yPos)
Takes two parameters - xPos and yPos and prints the ball accordingly.

- public void DeleteBall(int xPos, int yPos)
Uses two parameters - xPos and yPos in order to delete the ball from its current position.

- public void MoveBall()
Checks whether a key is pressed and acts accordingly.
If the right arrow is pressed, deletes the current ball position and sets it at a position equal to x + 1.
If the left arrow is pressed, deletes the current ball position and sets it at a position equal to x - 1.
  
- public void setY(int yPos)
If yPos > 0 and is also smaller than the width of the console, y is assigned  to it.*/


using System;
using System.Linq;

class Ball
{
    private int x, y;
    private string ballSymbol;

    public Ball()
    {
        this.x = TheBallGame.displayWidth / 2;
        this.y = TheBallGame.displayHeight - 1;
        this.ballSymbol = "O";
    }
    
    public void Init()
    {
        Console.SetCursorPosition(this.x, this.y);
        Console.Write(ballSymbol);
    }

    public void PrintAtPosition(int xPos, int yPos)
    {
        Console.SetCursorPosition(xPos, yPos);
        Console.Write(ballSymbol);
    }

    public void MoveBall()
    {
        while (Console.KeyAvailable)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                DeleteBall(x, y);
                if (x < TheBallGame.displayWidth - 1) x++;
                PrintAtPosition(x, y);
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                DeleteBall(x, y);
                if (x > 0) x--;
                PrintAtPosition(x, y);
            }
        }
    }

    public int X
    {
        get
        {
            return this.x;
        }
        /*set
        {
            if ((value > 0) && (value < Console.WindowWidth)) this.x = value;
        }*/
    }

    public int Y
    {
        get
        {
            return this.y;
        }
        set
        {
            if ((value > 0) && (value < Console.WindowHeight - 1)) this.y = value;
        }
    }
    
    /*public void setY(int yPos)
    {
        if ((yPos > 0) && (yPos < Console.WindowHeight - 1)) y = yPos;
    }*/

    public void DeleteBall(int xPos, int yPos)
    {
        Console.SetCursorPosition(xPos, yPos);
        Console.Write(" ");
    }
}


