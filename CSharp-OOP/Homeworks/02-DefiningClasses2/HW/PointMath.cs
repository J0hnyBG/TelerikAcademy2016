namespace HW
{
    //Problem 3
    using System;
    using HW.Points;

    public static class PointMath
    {
        public static double GetDistance(Point3D p1, Point3D p2)
        {
            return Math.Sqrt(
                GetPower(p1.X - p2.X, 2)
                + GetPower(p1.Y - p2.Y, 2)
                + GetPower(p1.Z - p2.Z, 2));
        }

        private static double GetPower(int a, int power)
        {
            double result = 1;
            for (var i = 0; i < power; i++)
            {
                result *= a;
            }
            return result;

        }


    }
}
