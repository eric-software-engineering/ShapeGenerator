using System;
using System.Drawing;

namespace ShapeGenerator.Core.Classes
{
    public class RegularPolygon : PolygonSideLength
    {
        public RegularPolygon(int vertices_count) => VerticesCount = vertices_count;

        public override void CalculateVerticesPosition()
        {
            var angle = 2 * Math.PI / VerticesCount;
            var radius = SideLength / (2 * Math.Sin(angle / 2));

            for (int i = 0; i < VerticesCount; i++)
            {
                var x = CenterX + radius * Math.Cos(i * angle);
                var y = CenterY + radius * Math.Sin(i * angle);
                Vertices.Add(new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
            }
        }
    }
}
