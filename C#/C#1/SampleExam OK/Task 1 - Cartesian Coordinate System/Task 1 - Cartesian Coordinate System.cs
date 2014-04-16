using System;

class Task1CartesianCoordinateSystem
{
    static void Main()
    {
        double x, y;
        int result=0;

        x = double.Parse(Console.ReadLine());
        y = double.Parse(Console.ReadLine());

        if ((x == 0) & (y == 0)) result = 0;
        else if (x == 0) result = 5;
        else if (y == 0) result = 6;
        else if ((x > 0) & (y > 0)) result = 1;
        else if ((x < 0) & (y > 0)) result = 2;
        else if ((x < 0) & (y < 0)) result = 3;
        else result = 4;

        Console.WriteLine(result);

    }
}

