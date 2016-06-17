namespace HW
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Generic;
    using Points;
    using Paths;
    using Matrix;
    using Version;

    [Version("1.81")]
    class Startup
    {
        private const string FileName = "pathTest"; //.txt
        //All the tasks are in one solution for convenience.
        static void Main()
        {
            #region Problems 1-4

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
                p1,
                p2,
                p3,
                p4,
                p5
            });

            //Currently saves paths in plantext format to root solition folder next to .sln file, aka two folders up from Debug folder
            Console.WriteLine("Saving Path to file.\n");
            PathStorage.SavePathToDisk(path, FileName);

            Console.WriteLine("Reading and printing Path from file:");
            var readpath = PathStorage.ReadPathFromDisk(FileName);

            Console.WriteLine(readpath.ToString());

            #endregion

            #region Problems 5-7

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
            Console.WriteLine(
                "Generic list before sorting. Point3D implements IComparable by comparing the sums of all coordinates.");
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

            #endregion

            #region Problems 8-10

            //Matrices
            Console.WriteLine("Problems 8-10 ".PadRight(50, '#'));
            Console.WriteLine("Creating two Matrix objects holding doubles.");
            double[,] arr =
            {
                {1.12, 4.213, 6.123},
            };
            double[,] arr2 =
            {
                {2.123, 3.123},
                {5.123, 8.123},
                {7.123, 9.123},
            };

            Matrix<double> matrix = new Matrix<double>(arr);
            Matrix<double> matrix2 = new Matrix<double>(arr2);
            Console.WriteLine(matrix);
            Console.WriteLine(matrix2);

            Console.WriteLine("Multiplying the matrices: ");
            Console.WriteLine(matrix*matrix2);
            Console.WriteLine("Creating two new Matrix objects holding ints:");
            int[,] mat1 =
            {
                {1, 4, 6, 12},
                {24, 48, 96, 192},
                {384, 768, 1536, 3072},
                {6144, 12288, 24576, 49152},
            };
            int[,] mat2 =
            {
                {12, 6, 4, 1},
                {192, 96, 48, 24},
                {3072, 1536, 768, 384},
                {49152, 24576, 12288, 6144},
            };

            Matrix<int> intMat1 = new Matrix<int>(mat1);
            Matrix<int> intMat2 = new Matrix<int>(mat2);
            Console.WriteLine(intMat1.ToString());
            Console.WriteLine(intMat2.ToString());
            Console.WriteLine("Adding the two matrices: ");
            Console.WriteLine(intMat1 + intMat2);
            Console.WriteLine("Substracting the two matrices: ");
            Console.WriteLine(intMat1 - intMat2);

            var emptyMatrix = new Matrix<int>(5, 5);
            Console.WriteLine("Boolean operators matrix with zeros. Should return false.");

            if (emptyMatrix)
            {
                Console.WriteLine("True\n");
            }
            else if (!emptyMatrix)
            {
                Console.WriteLine("False\n");
            }

            Console.WriteLine("Boolean operators on non-empty matrix. Should return true: ");
            if (intMat1)
            {
                Console.WriteLine("True\n");
            }
            else if (!intMat1)
            {
                Console.WriteLine("False\n");
            }

            #endregion

            #region Problem 11

            //Versions
            Console.WriteLine("Problem 11 ".PadRight(50, '#'));

            Console.WriteLine("Starting version cheking: ");
            Type type = typeof(Startup);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (var attr in allAttributes)
            {
                Console.WriteLine($"Startup class's version is {attr.ToString()}");
            }
            type = typeof(Matrix<>);
            allAttributes = type.GetCustomAttributes(false);

            Console.WriteLine($"Matrix class's version is {allAttributes[1].ToString()}");

            foreach (MethodInfo method in (typeof(Matrix<>)).GetMethods())
            {
                allAttributes = method.GetCustomAttributes(true);
                foreach (var attr in allAttributes)
                {
                    if (attr is VersionAttribute)
                    {
                        Console.WriteLine($"Matrix's {method.Name} method is version {attr.ToString()}");
                    }
                }
            }

            #endregion
        }
    }
}