using System;
using System.Linq;

namespace GeometryAPI
{
    public class Circle:Figure, IAreaMeasurable, IFlat
    {
        private double radius;
        private Vector3D center;

        public Circle(Vector3D center, double radius):base(center)//(new Vector3D(center.X,center.Y,0))
        {
            this.radius = radius;
            this.center = center;
        }

        public double GetArea()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }

        public Vector3D GetNormal()
        {
            Vector3D center = this.GetCenter();

            Vector3D A = new Vector3D(center.X + this.radius, center.Y, center.Z),
                     B = new Vector3D(center.X, center.Y + this.radius, center.Z);

            Vector3D normalVector = Vector3D.CrossProduct(center - A, center - B);
            normalVector.Normalize();

            return normalVector;
        }
    }
}
