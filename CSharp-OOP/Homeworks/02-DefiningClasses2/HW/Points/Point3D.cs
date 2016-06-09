namespace HW.Points
{
    using System;
    //Problem 1
    public struct Point3D : IComparable
    {
        public int X, Y, Z;

        public long Sum => X + Y + Z;

        //Problem 2
        private static readonly Point3D o = new Point3D(0, 0, 0);

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D O
        {
            get { return o; }
        }

        public override string ToString()
        {
            return $"X: {this.X} Y: {this.Y} Z: {this.Z}";
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (obj is Point3D)
            {
                Point3D p = (Point3D)obj;
                return this.Sum.CompareTo(p.Sum);
            }
            else
            {
                throw new ArgumentException("Object is not a Point!");
            }
        }
    }
}
