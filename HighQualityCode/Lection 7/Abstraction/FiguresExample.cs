namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        private static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine("I am a circle. " + "My perimeter is {0:f2}. My surface is {1:f2}.", circle.CalcPerimeter(), circle.CalcSurface());
            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle. " + "My perimeter is {0:f2}. My surface is {1:f2}.", rect.CalcPerimeter(), rect.CalcSurface());

            Figure circle1 = new Circle(5);
            Console.WriteLine("I am a circle. " + "My perimeter is {0:f2}. My surface is {1:f2}.", circle1.CalcPerimeter(), circle1.CalcSurface());
            Figure rect1 = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle. " + "My perimeter is {0:f2}. My surface is {1:f2}.", rect1.CalcPerimeter(), rect1.CalcSurface());
        }
    }
}
