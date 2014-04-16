using System;
using System.Linq;

namespace Shapes
{
    public class Triangle:Shape
    {
        public Triangle(int triangleSide, int triangleHeight) : base(triangleSide, triangleHeight)
        {

        }

        public override double CalculateSurface()
        {
            double result = this.Width * this.Height;
            
            result /= 2;
 
            return result;
        }
    }
}
