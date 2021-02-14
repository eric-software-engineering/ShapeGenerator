using System;
using System.Drawing;

namespace ShapeGenerator.Test
{
    public static class TestHelpers
    {
        public static double Distance(this Point p1, Point p2)
        {
            return Math.Round(Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2)), 1);
        }
    }
}
