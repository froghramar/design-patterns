using DesignPatterns.Factories;

namespace Tests;

public class ShapeFactoryTests
{
    [Fact]
    public void CreateShape_Circle_ReturnsCircle()
    {
        var shape = ShapeFactory.CreateShape(ShapeType.Circle, 1.23);
        Assert.IsType<Circle>(shape);
        Assert.Equal("Circle with radius 1.23", shape.Draw());
    }

    [Fact]
    public void CreateShape_Square_ReturnsSquare()
    {
        var shape = ShapeFactory.CreateShape(ShapeType.Square, 2.0);
        Assert.IsType<Square>(shape);
        Assert.Equal("Square with side 2", shape.Draw());
    }

    [Fact]
    public void CreateShape_Rectangle_ReturnsRectangle()
    {
        var shape = ShapeFactory.CreateShape(ShapeType.Rectangle, 3.0, 4.0);
        Assert.IsType<Rectangle>(shape);
        Assert.Equal("Rectangle 3x4", shape.Draw());
    }

    [Fact]
    public void CreateShape_InvalidParameters_Throws()
    {
        Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(ShapeType.Circle));
        Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(ShapeType.Rectangle, 1.0)); // missing height
    }
}
