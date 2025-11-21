using System.Globalization;

namespace DesignPatterns.Factories;

public sealed class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius));
        Radius = radius;
    }

    public string Draw() => $"Circle with radius {Radius.ToString("G", CultureInfo.InvariantCulture)}";
}
