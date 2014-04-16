using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes
{
    class MainProgram
    {
        static void Main()
        {
            List<Shape> shapes = new List<Shape>() {new Rectangle(3,5),
                                                    new Triangle(7,6),
                                                    new Circle(8)};
            foreach (var shape in shapes)
            {
                Console.WriteLine("The surface of {0} is {1}", shape.GetType().ToString().Substring(shape.GetType().ToString().LastIndexOf('.') + 1), shape.CalculateSurface());    
            }
        }
    }
}
