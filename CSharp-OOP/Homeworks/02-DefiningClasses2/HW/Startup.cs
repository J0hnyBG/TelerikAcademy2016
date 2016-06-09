using System.Collections.Generic;

namespace HW
{
    using Points;
    using Paths;

    class Startup
    {
        static void Main()
        {
            var point1 = new Point3D(-2000000000, 0, 0);
            var point2 = new Point3D(2000000000, 2000000000, 2000000000);
            var path = new Path(new List<Point3D>() {point1, point2});

            //Saves paths in plantext format to root solition folder next to .sln file
            PathStorage.SavePathToDisk(path, "path1");
            var readpath = PathStorage.ReadPathFromDisk("path1");
        }
    }
}
