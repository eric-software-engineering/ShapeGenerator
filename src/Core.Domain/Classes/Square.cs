using System.Drawing;

namespace ShapeGenerator.Core.Classes
{
    public class Square : PolygonSideLength
    {
        public override void CalculateVerticesPosition()
        {
            Vertices.Add(new Point(SideLength / 2 + CenterX, SideLength / 2 + CenterY));
            Vertices.Add(new Point(-SideLength / 2 + CenterX, SideLength / 2 + CenterY));
            Vertices.Add(new Point(-SideLength / 2 + CenterX, -SideLength / 2 + CenterY));
            Vertices.Add(new Point(SideLength / 2 + CenterX, -SideLength / 2 + CenterY));
        }
    }
}
