using Core.Domain.ExtensionMethods;
using Core.Services.Interfaces;
using ShapeGenerator.Core.Attributes;
using ShapeGenerator.Core.Classes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Services.Classes
{
    public class NaturalLanguageService : INaturalLanguageService
    {
        public Shape Compile(string input, int center_x, int center_y)
        {
            if (string.IsNullOrEmpty(input))
                throw new InvalidDataException("The input cannot be empty");

            // Get the shape
            var regex_shape = new Regex(@"Draw \b(a|an)\b (?<shape>[a-zA-Z\s]*) with", RegexOptions.IgnoreCase);
            var match_shape = regex_shape.Match(input);

            if (!match_shape.Success)
                throw new InvalidDataException("The input must contain 'Draw a(n) <shape>'");

            var shape_name = match_shape.Groups["shape"].Value.ToLower();
            Shape shape = null;

            switch (shape_name)
            {
                case "isosceles triangle":
                    shape = new IsoscelesTriangle();
                    break;
                case "square":
                    shape = new Square();
                    break;
                case "scalene triangle":
                    shape = new ScaleneTriangle();
                    break;
                case "parallelogram":
                    shape = new Parallelogram();
                    break;
                case "equilateral triangle":
                    shape = new RegularPolygon(3);
                    break;
                case "pentagon":
                    shape = new RegularPolygon(5);
                    break;
                case "rectangle":
                    shape = new Rectangle();
                    break;
                case "hexagon":
                    shape = new RegularPolygon(6);
                    break;
                case "heptagon":
                    shape = new RegularPolygon(7);
                    break;
                case "octagon":
                    shape = new RegularPolygon(8);
                    break;
                case "circle":
                    shape = new Circle();
                    break;
                case "oval":
                    shape = new Oval();
                    break;
                default:
                    throw new InvalidDataException($"Shape '{shape_name}' not found");
            }

            shape.CenterX = center_x;
            shape.CenterY = center_y;

            // Get the properties
            var regex_attributes = new Regex(@"\b(and|with)\b a (?<key>[a-zA-Z\s]*) of (?<value>\d*)", RegexOptions.IgnoreCase);
            var match_attributes = regex_attributes.Matches(input);

            // We use reflection to find all the properties. 
            // This makes the function more flexible as it can now take an unlimited number of arguments 'with/and a(n) <measurement> of <amount>'
            foreach (Match item in match_attributes)
            {
                var property = shape.GetType().GetProperties().FirstOrDefault(x => ((ParserAttribute)x.GetCustomAttributes(typeof(ParserAttribute), false).FirstOrDefault())?.PropertyName == item.Groups["key"].Value);

                if (property == null)
                    throw new InvalidDataException($"Invalid argument '{item.Groups[0]}' for the shape '{shape_name}'");

                if (!item.Groups["value"].Value.TryCast(property.PropertyType, out var value))
                    throw new InvalidDataException($"Invalid argument type '{item.Groups[0]}' for the shape '{shape_name}'");

                property.SetValue(shape, value, null);
            }

            // Check that all the properties validate
            var ctx = new ValidationContext(shape);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(shape, ctx, results, true))
                throw new InvalidDataException($"Invalid argument(s) for the shape '{shape_name}':<br />" + string.Join("<br />", results.Select(x => $"{string.Join(" ", x.MemberNames)} - {x.ErrorMessage}")));

            return shape;
        }
    }
}
