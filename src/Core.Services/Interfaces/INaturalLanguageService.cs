using ShapeGenerator.Core.Classes;

namespace Core.Services.Interfaces
{
    public interface INaturalLanguageService
    {
        Shape Compile(string input, int center_x, int center_y);
    }
}