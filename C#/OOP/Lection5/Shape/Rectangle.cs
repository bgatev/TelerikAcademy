using System;
using System.Linq;

namespace Shapes
{
    public class Rectangle:Shape
    {
        public Rectangle(int rectangleWidth, int rectangleHeight) : base(rectangleWidth, rectangleHeight)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
