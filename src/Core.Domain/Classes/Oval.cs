using ShapeGenerator.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShapeGenerator.Core.Classes
{
    public class Oval : Shape
    {
        [Parser(PropertyName = "radius x")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int RadiusX { get; set; }

        [Parser(PropertyName = "radius y")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int RadiusY { get; set; }

        public override string ToSvgString()
        {
            return $"<ellipse cx='{CenterX}' cy='{CenterY}' rx='{RadiusX}' ry='{RadiusY}' />";
        }
    }
}
