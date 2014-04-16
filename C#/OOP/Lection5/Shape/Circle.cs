using System;
using System.Linq;

namespace Shapes
{
    public class Circle:Shape
    {
        public Circle(int diameter) : base(diameter, diameter)
        {

        }

        public override double CalculateSurface()
        {
            double result = this.Width * this.Height * Math.PI;

            result /= 4;

            return result;
        }
    }
}
