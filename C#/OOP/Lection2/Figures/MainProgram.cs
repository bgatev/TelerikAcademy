using Figures;
using GenericList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[Version("1.0", "This is my main class.")]
class MainProgram
{
    private const string FilePath = @"..\..\";
    private const string FileName = @"paths.txt";
    
    [Version("3.13", "Program starts here.")]
    public static void Main()
    {
        Point3D myPoint = new Point3D(0,1,2);
        Point3D firstPoint = new Point3D(1,2,3);
        Point3D secondPoint = new Point3D(2,3,4);
        Point3D thirdPoint = new Point3D(3,4,5);
        Point3D fourthPoint = new Point3D(4,5,6);
        
        Point3D O = new Point3D();
        O = Point3D.CoordinateStart;
        Console.WriteLine("Point O is with coordinates {0}",O.ToString());

        double distance = Calculation.Distance(firstPoint, secondPoint);
        Console.WriteLine("Distance between {0} and {1} is {2}",firstPoint, secondPoint, distance);

        Path myPath = new Path();

        myPath.AddPoint(myPoint);
        myPath.AddPoint(firstPoint);
        myPath.AddPoint(secondPoint);
        myPath.AddPoint(thirdPoint);
        myPath.AddPoint(fourthPoint);

        //PathStorage.SavePath(FilePath, FileName, myPath);

        Path loadedPath = PathStorage.LoadPath(FilePath,FileName);
        List<Point3D> loadedPoints = loadedPath.GetListOfPoint();
        foreach (var point in loadedPoints)
        {
            Console.WriteLine(point.ToString());   
        }

        GenericsList<int> intExample = new GenericsList<int>(2);
        intExample.Add(5);
        intExample.Add(3);
        intExample.Add(2);
        intExample.Add(10);
        intExample.Add(1);

        int a = intExample[3];
        intExample.Remove(1);
        intExample.Insert(55, 4);
        //intExample.ClearList();
        int index = intExample.Find(55);

        Console.WriteLine(intExample.ToString());
        int min = intExample.Min<int>();
        int max = intExample.Max<int>();

        Console.WriteLine("Minimal element is {0} and maximal is {1}",min, max);

        Matrix<int> mat = new Matrix<int>(3,3);
        int[,] matExample= new int[3,3] { {1, 1, 4},
                                          {2, 2, 3},
                                          {1, 4, 5} };
        mat[0, 0] = 3;
        mat[0, 2] = 31;
        mat[1, 1] = 5;
        mat[2, 0] = 13;
        
        Matrix<int> mat1 = new Matrix<int>(matExample);

        Matrix<int> matPlus = mat + mat1;
        Matrix<int> matMinus = mat - mat1;
        Matrix<int> matMultiply = mat * mat1;
        Matrix<double> matZero = new Matrix<double>(3, 3);

        bool isZero = matPlus ? true : false;
        bool is_Zero = matZero ? true : false;

        Console.WriteLine(isZero);
        Console.WriteLine(is_Zero);

        Type typeClass = typeof(MainProgram);
        object[] allAttributesClass = typeClass.GetCustomAttributes(false);
        foreach (VersionAttribute attr in allAttributesClass)
        {
            Console.WriteLine("My class is version {0} and {1}", attr.Version, attr.Comment);
        }

        MethodInfo[] infoMethods = typeClass.GetMethods(BindingFlags.Static | BindingFlags.Public);
        foreach (MethodInfo method in infoMethods)
        {
            object[] allAttributesMethod = method.GetCustomAttributes(false);
            foreach (VersionAttribute attr in allAttributesMethod)
            {
                Console.WriteLine("Method \"{0}\" version is {1} and {2}", method.Name, attr.Version, attr.Comment);
            }
        }



    }
}

