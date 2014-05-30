namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        private static void Main()
        {
            Console.WriteLine(Files.GetFileExtension("example"));
            Console.WriteLine(Files.GetFileExtension("example.pdf"));
            Console.WriteLine(Files.GetFileExtension("example.new.pdf"));

            Console.WriteLine(Files.GetFileNameWithoutExtension("example"));
            Console.WriteLine(Files.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(Files.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", Utils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Utils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Utils.Width = 3;
            Utils.Height = 4;
            Utils.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", Utils.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Utils.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Utils.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Utils.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Utils.CalcDiagonalYZ());
        }
    }
}
