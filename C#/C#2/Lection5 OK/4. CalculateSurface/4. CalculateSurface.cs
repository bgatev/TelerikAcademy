//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;
using System.Linq;

class CalculateSurface
{
    static void CalcTriangleSurfaceBySideAndAltitude()
    {
        double side, altitude;
        double surface = 0;

        side = double.Parse(Console.ReadLine());
        altitude = double.Parse(Console.ReadLine());

        surface = (side * altitude) / 2;
        Console.WriteLine(surface);
    }

    static void CalcTriangleSurfaceByThreeSides()
    {
        double side1, side2, side3;
        double surface = 0, p;

        side1 = int.Parse(Console.ReadLine());
        side2 = int.Parse(Console.ReadLine());
        side3 = int.Parse(Console.ReadLine());

        p = (side1 + side2 + side3) / 2;
        surface = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));

        Console.WriteLine(surface);
    }

    static void CalcTriangleSurfaceByTwoSidesAndAngle()
    {
        double side1, side2;
        double surface = 0, angle;

        side1 = double.Parse(Console.ReadLine());
        side2 = double.Parse(Console.ReadLine());
        angle = double.Parse(Console.ReadLine());

        surface = (side1 * side2 * Math.Sin((angle * Math.PI) / 180)) / 2;

        Console.WriteLine(surface);
    }
    
    static void Main()
    {
        int choice;

        Console.WriteLine("1. Calculate Triangle Surface by Side and Altitude");
        Console.WriteLine("2. Calculate Triangle Surface by Three Sides");
        Console.WriteLine("3. Calculate Triangle Surface by Two Sides and Angle between them");
        Console.Write("Please choose calculation method: ");
        
        choice = int.Parse(Console.ReadLine());
        
        switch (choice)
        {
            case 2: CalcTriangleSurfaceByThreeSides(); break;
            case 3: CalcTriangleSurfaceByTwoSidesAndAngle(); break;
            default: CalcTriangleSurfaceBySideAndAltitude(); break;
        }
    }
}

