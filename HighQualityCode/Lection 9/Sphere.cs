namespace Surfaces
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;

    public sealed class Sphere : Surface
    {
        private static PropertyHolder<double, Sphere> RadiusProperty = new PropertyHolder<double, Sphere>("Radius", 1.0, OnGeometryChanged);
        private static PropertyHolder<Point3D, Sphere> PositionProperty = new PropertyHolder<Point3D, Sphere>("Position", new Point3D(0, 0, 0), OnGeometryChanged);
        private double _radius;
        private Point3D _position;

        public double Radius
        {
            get { return RadiusProperty.Get(this); }
            set { RadiusProperty.Set(this, value); }
        }

        public Point3D Position
        {
            get { return PositionProperty.Get(this); }
            set { PositionProperty.Set(this, value); }
        }

        protected override Geometry3D CreateMesh()
        {
            _radius = this.Radius;
            _position = this.Position;

            const int ANGLESTEPS = 32;
            const double MINANGLE = 0;
            const double MAXANGLE = 2 * Math.PI;
            const double DANGLE = (MAXANGLE - MINANGLE) / ANGLESTEPS;

            const int YSTEPS = 32;
            const double MINY = -1.0;
            const double MAXY = 1.0;
            const double DY = (MAXY - MINY) / YSTEPS;

            MeshGeometry3D mesh = new MeshGeometry3D();

            for (int yi = 0; yi <= YSTEPS; yi++)
            {
                double y = MINY + yi * DY;

                for (int ai = 0; ai <= ANGLESTEPS; ai++)
                {
                    double angle = ai * DANGLE;

                    mesh.Positions.Add(GetPosition(angle, y));
                    mesh.Normals.Add(GetNormal(angle, y));
                    mesh.TextureCoordinates.Add(GetTextureCoordinate(angle, y));
                }
            }

            for (int yi = 0; yi < YSTEPS; yi++)
            {
                for (int ai = 0; ai < ANGLESTEPS; ai++)
                {
                    int a1 = ai;
                    int a2 = ai + 1;
                    int y1 = yi * (ANGLESTEPS + 1);
                    int y2 = (yi + 1) * (ANGLESTEPS + 1);

                    mesh.TriangleIndices.Add(y1 + a1);
                    mesh.TriangleIndices.Add(y2 + a1);
                    mesh.TriangleIndices.Add(y1 + a2);

                    mesh.TriangleIndices.Add(y1 + a2);
                    mesh.TriangleIndices.Add(y2 + a1);
                    mesh.TriangleIndices.Add(y2 + a2);
                }
            }

            mesh.Freeze();
            return mesh;
        }

        private Point3D GetPosition(double angle, double y)
        {
            double r = _radius * Math.Sqrt(1 - y * y);
            double x = r * Math.Cos(angle);
            double z = r * Math.Sin(angle);

            return new Point3D(_position.X + x, _position.Y + _radius * y, _position.Z + z);
        }

        private Vector3D GetNormal(double angle, double y)
        {
            return (Vector3D)GetPosition(angle, y);
        }

        private Point GetTextureCoordinate(double angle, double y)
        {
            Matrix map = new Matrix();
            map.Scale(1 / (2 * Math.PI), -0.5);

            Point p = new Point(angle, y);
            p = p * map;

            return p;
        }       
    }
}
