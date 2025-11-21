using System;

namespace DesignPatterns.Factories;

public static class ShapeFactory
{
    // Parameters interpreted per shape:
    // Circle    -> parameters[0] = radius
    // Square    -> parameters[0] = side
    // Rectangle -> parameters[0] = width, parameters[1] = height
    public static IShape CreateShape(ShapeType type, params double[] parameters)
    {
        return type switch
        {
            ShapeType.Circle when parameters.Length >= 1 => new Circle(parameters[0]),
            ShapeType.Square when parameters.Length >= 1 => new Square(parameters[0]),
            ShapeType.Rectangle when parameters.Length >= 2 => new Rectangle(parameters[0], parameters[1]),
            _ => throw new ArgumentException($"Invalid parameters for shape {type}", nameof(parameters))
        };
    }
}
