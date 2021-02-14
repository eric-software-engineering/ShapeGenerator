using System;

namespace ShapeGenerator.Core.Attributes
{
    /// <summary>
    /// Attribute used to match input strings with properties
    /// </summary>
    public class ParserAttribute : Attribute
    {
        public string PropertyName { get; set; }
    }
}
