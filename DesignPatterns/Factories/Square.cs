using System;
using System.Globalization;

namespace DesignPatterns.Factories;

public sealed class Square : IShape
{
    public double Side { get; }

    public Square(double side)
    {
        if (side <= 0) throw new ArgumentOutOfRangeException(nameof(side));
        Side = side;
    }

    public string Draw() => $"Square with side {Side.ToString("G", CultureInfo.InvariantCulture)}";
}
