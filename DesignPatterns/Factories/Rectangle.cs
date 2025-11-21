using System;
using System.Globalization;

namespace DesignPatterns.Factories;

public sealed class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));
        if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
        Width = width;
        Height = height;
    }

    public string Draw() => $"Rectangle {Width.ToString("G", CultureInfo.InvariantCulture)}x{Height.ToString("G", CultureInfo.InvariantCulture)}";
}
