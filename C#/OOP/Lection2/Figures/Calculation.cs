using System;
using System.Linq;

namespace Figures
{
    public static class Calculation
    {
        public static double Distance(Point3D firstPoint, Point3D secondPoint)
        {
            double distance = Math.Sqrt((firstPoint.X - secondPoint.X) * (firstPoint.X - secondPoint.X)
                + (firstPoint.Y - secondPoint.Y) * (firstPoint.Y - secondPoint.Y) + (firstPoint.Z - secondPoint.Z) * (firstPoint.Z - secondPoint.Z));

            return distance;
        }
    }
}
