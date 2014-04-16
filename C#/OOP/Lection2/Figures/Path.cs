using System;
using System.Collections.Generic;
using System.Linq;

namespace Figures
{
    public class Path
    {
        private List<Point3D> listOfPoints = new List<Point3D>();

        public void AddPoint(Point3D pointToAdd)
        {
            listOfPoints.Add(pointToAdd);
        }

        public List<Point3D> GetListOfPoint()
        {
            return listOfPoints;
        }
    }
}
