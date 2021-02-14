using System.Drawing;

namespace ShapeGenerator.Core.Classes
{
    public class IsoscelesTriangle : PolygonHeightAndWidth
    {
        public override void CalculateVerticesPosition()
        {
            Vertices.Add(new Point(CenterX - Height / 2, CenterY));
            Vertices.Add(new Point(CenterX + Height / 2, CenterY - Width / 2));
            Vertices.Add(new Point(CenterX + Height / 2, CenterY + Width / 2));
        }
    }
}
