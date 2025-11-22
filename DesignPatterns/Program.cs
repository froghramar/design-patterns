using DesignPatterns.Factories;
using DesignPatterns.Singleton;
using DesignPatterns.Builder;
using DesignPatterns.Prototype;
using DesignPatterns.AbstractFactory;
using DesignPatterns.Adapter;
using DesignPatterns.Bridge;
using DesignPatterns.Composite;

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

// Abstract Factory demo
Console.WriteLine();
Console.WriteLine("Abstract Factory pattern demo:");
var modernFactory = FactoryProducer.GetFactory(FactoryProducer.Style.Modern);
var modernChair = modernFactory.CreateChair();
var modernSofa = modernFactory.CreateSofa();
Console.WriteLine(modernChair.Sit());
Console.WriteLine(modernSofa.LieDown());

var victorianFactory = FactoryProducer.GetFactory(FactoryProducer.Style.Victorian);
var victorianChair = victorianFactory.CreateChair();
var victorianSofa = victorianFactory.CreateSofa();
Console.WriteLine(victorianChair.Sit());
Console.WriteLine(victorianSofa.LieDown());

// Adapter demo
Console.WriteLine();
Console.WriteLine("Adapter pattern demo:");
var legacy = new LegacyTextService();
ITextProvider provider = new LegacyTextAdapter(legacy);
Console.WriteLine(provider.GetText());

// Bridge demo
Console.WriteLine();
Console.WriteLine("Bridge pattern demo:");
var tv = new Tv();
var remote = new RemoteControl(tv);
remote.TogglePower();
remote.VolumeUp();
remote.SetChannel(10);
Console.WriteLine($"TV - Enabled: {tv.IsEnabled}, Volume: {tv.Volume}, Channel: {tv.Channel}");

var radio = new Radio();
var adv = new AdvancedRemote(radio);
adv.VolumeUp();
adv.Mute();
Console.WriteLine($"Radio - Enabled: {radio.IsEnabled}, Volume: {radio.Volume}, Channel: {radio.Channel}");

// Composite demo
Console.WriteLine();
Console.WriteLine("Composite pattern demo:");
var root = new CompositeGraphic();
root.Add(new Dot());
root.Add(new CircleGraphic());
Console.WriteLine(root.Draw());

var nested = new CompositeGraphic();
var child = new CompositeGraphic();
child.Add(new Dot());
nested.Add(child);
nested.Add(new CircleGraphic());
Console.WriteLine(nested.Draw());

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
