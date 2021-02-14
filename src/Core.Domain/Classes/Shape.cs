using System.ComponentModel.DataAnnotations;

namespace ShapeGenerator.Core.Classes
{
    public abstract class Shape
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int CenterX { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int CenterY { get; set; }

        public abstract string ToSvgString();
    }
}
