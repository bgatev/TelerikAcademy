namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public Circle() : this(0)
        {
        }

        public double Radius { get; set; }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}
