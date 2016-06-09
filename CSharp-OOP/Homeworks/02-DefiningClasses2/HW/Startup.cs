using System;

namespace HW
{
    using System.Collections.Generic;
    using Generic;
    using Points;
    using Paths;

    class Startup
    {
        static void Main()
        {
            //Testing the points
            Console.WriteLine("Creating Point3D's and a Path.\n");
            var p1 = new Point3D(10000000, 0, 0);
            var p2 = new Point3D(1, 1, 0);
            var p3 = new Point3D(1, 1, 1);
            var p4 = new Point3D(100, 123, 456);
            var p5 = new Point3D(100, 5, 780);

            var path = new Path(new List<Point3D>()
            {
                p1, p2, p3 ,p4, p5
            });

            //Saves paths in plantext format to root solition folder next to .sln file, aka two folders up from Debug folder
            Console.WriteLine("Saving Path to file.\n");
            PathStorage.SavePathToDisk(path, "path1");

            Console.WriteLine("Reading and printing Path from file.");
            var readpath = PathStorage.ReadPathFromDisk("path1");

            Console.WriteLine(readpath.ToString());

            Console.WriteLine("Creating new GenericList of Point3D's and adding the points:");

            var listInt = new List<int>(10);
            var pointList = new GenericList<Point3D>();
            pointList.Add(p1);
            pointList.Add(p2);
            pointList.Add(p3);
            pointList.Add(p4);
            pointList.Add(p5);
            Console.WriteLine(pointList.ToString());

            Console.WriteLine($"Inserting point: {p4} at index 2:");
            pointList.Insert(2, p4);
            Console.WriteLine(pointList.ToString());
            var index = pointList.IndexOf(p3);

            Console.WriteLine($"IndexOf Point {p3} is: {index}:");
            Console.WriteLine(pointList.ToString());

            Point3D p3clone = pointList[index];
            Console.WriteLine($"Accessed and removed point: {p3clone} by index: {index}:");
            pointList.RemoveAt(index);
            Console.WriteLine(pointList.ToString());

            Console.WriteLine($"Removed point - {p1} - by value:");
            pointList.Remove(p1);
            Console.WriteLine(pointList.ToString());

            pointList.Add(p1);
            pointList.Add(p2);
            pointList.Add(p3);
            pointList.Add(p4);
            pointList.Add(p5);

            var max = pointList.Max();
            var min = pointList.Min();
            Console.WriteLine("Generic list before sorting. Point3D implements IComparable by comparing the sums of all coordinates.");
            Console.WriteLine($"Max value of unsorted list: {max}. Min value of unsorted list: {min}");
            Console.WriteLine(pointList.ToString());


            pointList.Sort();
            Console.WriteLine("Generic list after sorting:");
            Console.WriteLine(pointList.ToString());
        }
    }
}
