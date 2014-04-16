using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Figures
{
    public static class PathStorage
    {
        public static Path LoadPath(string FilePath, string FileName)
        {
            Path result = new Path();

            try
            {
                using (StreamReader reader = new StreamReader(FilePath + FileName, Encoding.GetEncoding("windows-1251")))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] coordinates = line.Split(',');
                        Point3D currentPoint = new Point3D(int.Parse(coordinates[0]), int.Parse(coordinates[1]), int.Parse(coordinates[2]));
                        result.AddPoint(currentPoint);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Argument - Please see your variables");
            }

            return result;
        }

        public static void SavePath(string FilePath, string FileName, Path newPath)
        {         
            List<Point3D> listToSave = newPath.GetListOfPoint();

            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath + FileName, false, Encoding.GetEncoding("windows-1251")))
                {
                    foreach (var currentPoint in listToSave)
                    {
                        writer.WriteLine(currentPoint.ToString());        
                    }
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid Argument - Please see your variables");
            }
        }
    }
}
