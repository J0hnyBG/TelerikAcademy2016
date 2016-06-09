namespace HW.Paths
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using HW.Points;

    public static class PathStorage
    {
       private static readonly DirectoryInfo SaveDirectory = 
            Directory.GetParent(
                Directory.GetParent(
                    Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString());

        //Saves paths in plantext format to root solition folder next to .sln file
       public static void SavePathToDisk(Path path, string fileName)
        {
            string[] lines = new string[path.Points.Count];

            for (int i = 0; i < path.Points.Count; i++)
            {
                lines[i] = path.Points[i].ToString();
            }
            
            File.WriteAllLines($"{SaveDirectory}\\{fileName}.txt", lines);
        }
        //Reads path files from root solution folder
        public static Path ReadPathFromDisk(string fileName)
        {
            List<Point3D> pointList = new List<Point3D>();
            try
            {   
                using ( StreamReader sr = new StreamReader($"{SaveDirectory}\\{fileName}.txt") )
                {
                    string[] line = sr.ReadToEnd().Split(new [] {' ', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 1; i < line.Length; i+=6)
                    {
                        var x = int.Parse(line[i]);
                        var y = int.Parse(line[i+2]);
                        var z = int.Parse(line[i+4]);

                        pointList.Add(new Point3D(x, y ,z));
                    }
                }
            }
            catch ( Exception e )
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return new Path(pointList);
        }
    }
}
