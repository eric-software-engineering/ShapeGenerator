using System.Drawing;

namespace ShapeGenerator.Core.Classes
{
    public class Parallelogram : PolygonHeightAndWidth
    {
        public override void CalculateVerticesPosition()
        {
            Vertices.Add(new Point(Height / 2 + CenterX - 10, Width / 2 + CenterY));
            Vertices.Add(new Point(-Height / 2 + CenterX, Width / 2 + CenterY));
            Vertices.Add(new Point(-Height / 2 + CenterX + 10, -Width / 2 + CenterY));
            Vertices.Add(new Point(Height / 2 + CenterX, -Width / 2 + CenterY));
        }
    }
}
