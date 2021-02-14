using ShapeGenerator.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShapeGenerator.Core.Classes
{
    public abstract class PolygonHeightAndWidth : Polygon
    {
        [Parser(PropertyName = "height")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Height { get; set; }

        [Parser(PropertyName = "width")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Width { get; set; }
    }
}
