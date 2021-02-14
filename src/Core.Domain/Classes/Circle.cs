using ShapeGenerator.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShapeGenerator.Core.Classes
{
    public class Circle : Shape
    {
        [Parser(PropertyName = "radius")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Radius { get; set; }

        public override string ToSvgString()
        {
            return $"<circle cx='{CenterX}' cy='{CenterY}' r='{Radius}' />";
        }
    }
}
