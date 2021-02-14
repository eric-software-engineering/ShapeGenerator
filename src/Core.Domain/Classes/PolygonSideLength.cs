using ShapeGenerator.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ShapeGenerator.Core.Classes
{
    public abstract class PolygonSideLength : Polygon
    {
        [Parser(PropertyName = "side length")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int SideLength { get; set; }
    }
}
