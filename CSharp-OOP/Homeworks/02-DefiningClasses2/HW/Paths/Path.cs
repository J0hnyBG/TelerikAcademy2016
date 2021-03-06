﻿namespace HW.Paths
{
    //Problem 4
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Points;

    public class Path
    {
        public Path(List<Point3D> points)
        {
            this.Points = points;
        }

        public List<Point3D> Points { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var point in Points)
            {
                sb.Append(point + Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}