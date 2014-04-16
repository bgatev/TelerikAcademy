/*class RandomIndex
Variables:
-	RG – generates random positions of the hole*/



/*class Floor

Variables:

- int yPos - sets the position of the ball on the y-axis
- int holePos - sets the position of the hole
- string FloorContent - describes what the floor will look like

The Floor class consists of 2 methods as it follows:

- public Floor(string floorContent)
Takes the floorContent string as a parameter and generates the floor.
If floorContent is an empty string, yPos is set to the height of the console and the hole position is set to -1.
Otherwise, the hole position is generated randomly and the floor itself consists of spaces and dashes.

- public void Move()
Checks if y-axis position is larger than 1. In case it is, sets new position by subtracting 2 from the current position. Prints the floor.*/

using System;
using System.Linq;

public static class RandomIndex
{
    public static Random RG = new Random();
}

class Floor
{
    private int yPos;
    private int holePos;
    private string floorContent;

    public Floor(string flContent)
    {
        this.floorContent = flContent;
        if (this.floorContent.Equals("")) 
        {
            this.yPos = TheBallGame.displayHeight;
            this.holePos = -1;
        }
        else
        {
            this.holePos = RandomIndex.RG.Next(1, TheBallGame.displayWidth - 3);
            this.floorContent = new string('-', this.holePos) + "   " + new string('-', TheBallGame.displayWidth - this.holePos - 3);
            this.yPos = TheBallGame.displayHeight; 
        }        
    }

    public int YPos
    {
        get
        {
            return this.yPos;
        }
        set
        {
            this.yPos = value;
        }
    }

    public int HolePos
    {
        get
        {
            return this.holePos;
        }
        set
        {
            this.holePos = value;
        }
    }
   
    
    public void Move()
    {
        if (this.yPos > 1)
        {
            this.yPos -= 2;
            Console.SetCursorPosition(0, this.yPos);
            Console.Write(this.floorContent);
        }
    }

}

