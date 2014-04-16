using System;
using System.Linq;

namespace GeometryAPI
{
    public class Cylinder: Figure, IAreaMeasurable, IVolumeMeasurable
    {
        private double radius;
        private Vector3D bottom, top;

        public Cylinder(Vector3D bottom, Vector3D top, double radius) : base(bottom,top)
        {
            this.radius = radius;
            this.bottom = bottom;
            this.top = top;
        }

        public double GetArea()
        {
            double h = (this.top - this.bottom).Magnitude;
            
            return 2 * Math.PI * this.radius * (this.radius + h);
        }

        public double GetVolume()
        {
            double h = (this.top - this.bottom).Magnitude;
            
            return Math.PI * this.radius * this.radius * h;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }
    }
}
