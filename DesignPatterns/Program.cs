using DesignPatterns.Factories;
using DesignPatterns.Singleton;
using DesignPatterns.Builder;

Console.WriteLine("Factory pattern demo:");

IShape circle = ShapeFactory.CreateShape(ShapeType.Circle, 3.5);
IShape square = ShapeFactory.CreateShape(ShapeType.Square, 2.0);
IShape rect = ShapeFactory.CreateShape(ShapeType.Rectangle, 4.0, 1.5);

Console.WriteLine(circle.Draw());
Console.WriteLine(square.Draw());
Console.WriteLine(rect.Draw());

// Builder demo
var house = new HouseBuilder()
    .WithRooms(3)
    .WithWindows(5)
    .WithGarage()
    .AtAddress("123 Main St")
    .Build();

Console.WriteLine();
Console.WriteLine("Builder pattern demo:");
Console.WriteLine(house.ToString());

// Singleton demo
Logger.Instance.Clear();
Logger.Instance.Log("Singleton started");
Logger.Instance.Log("Singleton finished");

Console.WriteLine();
Console.WriteLine("Logged messages:");
foreach (var msg in Logger.Instance.Messages)
{
    Console.WriteLine(msg);
}
