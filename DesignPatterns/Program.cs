using DesignPatterns.Factories;

Console.WriteLine("Factory pattern demo:");

IShape circle = ShapeFactory.CreateShape(ShapeType.Circle, 3.5);
IShape square = ShapeFactory.CreateShape(ShapeType.Square, 2.0);
IShape rect = ShapeFactory.CreateShape(ShapeType.Rectangle, 4.0, 1.5);

Console.WriteLine(circle.Draw());
Console.WriteLine(square.Draw());
Console.WriteLine(rect.Draw());
