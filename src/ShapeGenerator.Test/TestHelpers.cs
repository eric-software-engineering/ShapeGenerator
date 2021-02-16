using System;
using System.Drawing;

namespace ShapeGenerator.Test
{
    public static class TestHelpers
    {
        /// <summary>
        /// Extension method to calculate the distance between two points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double Distance(this Point p1, Point p2)
        {
            return Math.Round(Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2)), 1);
        }
    }
}
