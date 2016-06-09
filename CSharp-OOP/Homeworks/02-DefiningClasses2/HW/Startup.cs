using System;

namespace HW
{
    using System.Collections.Generic;
    using Generic;
    using Points;
    using Paths;

    class Startup
    {
        private const string FileName = "pathTest";//.txt
        static void Main()
        {
            //Testing the points
            Console.WriteLine("Homework 2 Demo");
            Console.WriteLine("Problems 1-4 ".PadRight(50, '#'));

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
            PathStorage.SavePathToDisk(path, FileName);

            Console.WriteLine("Reading and printing Path from file:");
            var readpath = PathStorage.ReadPathFromDisk(FileName);

            Console.WriteLine(readpath.ToString());

            Console.WriteLine("Problems 5-7 + sorting ".PadRight(50, '#'));
            Console.WriteLine("\nCreating new GenericList of Point3D's and adding the points:");

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
            Console.WriteLine(pointList.ToString());
            Console.WriteLine($"Max value of unsorted list: {max}. Min value of unsorted list: {min}.\n");

            pointList.Sort();
            Console.WriteLine("Generic list after sorting:");
            Console.WriteLine(pointList.ToString());

            GenericList<int> intList = new GenericList<int>();
            intList.Add(5);
            intList.Add(3);
            intList.Add(4);
            intList.Add(1);
            intList.Add(2);

            Console.WriteLine("GenericList works with other types as long as they implement IComparable:");
            Console.WriteLine(intList);
            intList.Sort();
            Console.WriteLine("And sorts them:");
            Console.WriteLine(intList);

            GenericList<string> stringList = new GenericList<string>();
            stringList.Add("Zoo");
            stringList.Add("Camel");
            stringList.Add("Why");
            stringList.Add("Apricot");
            stringList.Add("Orange");

            Console.WriteLine("Again unsorted:");
            Console.WriteLine(stringList);
            stringList.Sort();
            Console.WriteLine("Sorted:");
            Console.WriteLine(stringList);

        }
    }
}
