using DesignPatterns.Factories;
using DesignPatterns.Singleton;
using DesignPatterns.Builder;
using DesignPatterns.Prototype;

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

// Prototype demo
var person = new Person("Alice", 30, new Address("1 A St", "Townsville"));
var clone = person.Clone();
clone.Address.Street = "2 B Ave"; // modify clone's address to demonstrate deep copy

Console.WriteLine();
Console.WriteLine("Prototype pattern demo:");
Console.WriteLine($"Original: {person}");
Console.WriteLine($"Clone:    {clone}");

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
