namespace HW.Points
{
    //Problem 1
    public struct Point3D
    {
        public int X, Y, Z;

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
    }
}
