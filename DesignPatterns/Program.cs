using DesignPatterns.Factories;
using DesignPatterns.Singleton;

Console.WriteLine("Factory pattern demo:");

IShape circle = ShapeFactory.CreateShape(ShapeType.Circle, 3.5);
IShape square = ShapeFactory.CreateShape(ShapeType.Square, 2.0);
IShape rect = ShapeFactory.CreateShape(ShapeType.Rectangle, 4.0, 1.5);

Console.WriteLine(circle.Draw());
Console.WriteLine(square.Draw());
Console.WriteLine(rect.Draw());

// Singleton demo
Logger.Instance.Clear();
Logger.Instance.Log("Application started");
Logger.Instance.Log(circle.Draw());
Logger.Instance.Log(square.Draw());
Logger.Instance.Log(rect.Draw());
Logger.Instance.Log("Application finished");

Console.WriteLine("Logged messages:");
foreach (var msg in Logger.Instance.Messages)
{
    Console.WriteLine(msg);
}
