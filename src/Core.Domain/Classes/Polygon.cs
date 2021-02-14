using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ShapeGenerator.Core.Classes
{
    public abstract class Polygon : Shape
    {
        public int VerticesCount { get; set; }
        public List<Point> Vertices { get; set; } = new List<Point>();

        public abstract void CalculateVerticesPosition();

        public override string ToSvgString()
        {
            CalculateVerticesPosition();
            var vertices = string.Join(" ", Vertices.Select(x => $"{x.Y},{x.X}"));
            return $"<polygon points='{vertices}' />";
        }
    }
}
