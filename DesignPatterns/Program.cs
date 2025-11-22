using DesignPatterns.Factories;
using DesignPatterns.Singleton;
using DesignPatterns.Builder;
using DesignPatterns.Prototype;
using DesignPatterns.AbstractFactory;
using DesignPatterns.Adapter;
using DesignPatterns.Bridge;
using DesignPatterns.Composite;
using DesignPatterns.Decorator;
using DesignPatterns.Facade;
using DesignPatterns.Flyweight;
using DesignPatterns.Proxy;
using DesignPatterns.Chain;
using DesignPatterns.Iterator;
using DesignPatterns.Mediator;

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

// Iterator demo
Console.WriteLine();
Console.WriteLine("Iterator pattern demo:");
var books = new BookCollection();
books.Add(new Book("Title1", "Author1"));
books.Add(new Book("Title2", "Author2"));

var it = books.CreateIterator();
while (it.HasNext())
{
    Console.WriteLine(it.Next());
}

// Chain of Responsibility demo
Console.WriteLine();
Console.WriteLine("Chain of Responsibility pattern demo:");
var h1 = new LevelOneHandler();
var h2 = new LevelTwoHandler();
var def = new DefaultHandler();
h1.SetNext(h2).SetNext(def);

Console.WriteLine(h1.Handle(new Request(1, "r1")));
Console.WriteLine(h1.Handle(new Request(2, "r2")));
Console.WriteLine(h1.Handle(new Request(99, "r3")));

// Command demo
Console.WriteLine();
Console.WriteLine("Command pattern demo:");
var light = new DesignPatterns.Command.Light();
var lightOn = new DesignPatterns.Command.LightOnCommand(light);
var lightOff = new DesignPatterns.Command.LightOffCommand(light);
var cmdRemote = new DesignPatterns.Command.RemoteControl();

cmdRemote.SetCommand(lightOn);
cmdRemote.PressButton();
Console.WriteLine($"Light is on: {light.IsOn}");

cmdRemote.SetCommand(lightOff);
cmdRemote.PressButton();
Console.WriteLine($"Light is on: {light.IsOn}");

// demonstrate undo
cmdRemote.SetCommand(lightOn);
cmdRemote.PressButton();
cmdRemote.PressUndo();
Console.WriteLine($"After undo, light is on: {light.IsOn}");

// Mediator demo
Console.WriteLine();
Console.WriteLine("Mediator pattern demo:");
var room = new ChatRoom();
var alice = new Participant("Alice");
var bob = new Participant("Bob");
room.Register(alice);
room.Register(bob);

alice.Send("Hello Bob");
Console.WriteLine("Bob's messages:");
foreach (var m in bob.Messages) Console.WriteLine(m);

// Decorator demo
Console.WriteLine();
Console.WriteLine("Decorator pattern demo:");
INotifier notifier = new EmailNotifier();
Console.WriteLine(notifier.Notify("Hello"));

notifier = new SmsDecorator(notifier);
Console.WriteLine(notifier.Notify("Hello"));

notifier = new SlackDecorator(notifier);
Console.WriteLine(notifier.Notify("Hello"));

// Facade demo
Console.WriteLine();
Console.WriteLine("Facade pattern demo:");
var facade = new OrderFacade();
if (facade.PlaceOrder("Bob", "Widget", 2, "1 Road", 9.99m, out var confirmation))
{
    Console.WriteLine("Order placed: " + confirmation);
}
else
{
    Console.WriteLine("Order failed");
}

if (!facade.PlaceOrder("Bob", "Widget", 999, "1 Road", 9.99m, out _))
{
    Console.WriteLine("Second order failed as expected (out of stock)");
}

// Flyweight demo
Console.WriteLine();
Console.WriteLine("Flyweight pattern demo:");
var t1 = TreeFactory.GetTreeType("Oak", "Green", "Rough");
var t2 = TreeFactory.GetTreeType("Oak", "Green", "Rough");
var t3 = TreeFactory.GetTreeType("Pine", "DarkGreen", "Smooth");

var tree1 = new Tree(10, 20, t1);
var tree2 = new Tree(15, 25, t2);
var tree3 = new Tree(5, 5, t3);

Console.WriteLine(tree1.Draw());
Console.WriteLine(tree2.Draw());
Console.WriteLine(tree3.Draw());
Console.WriteLine($"Shared types count: {TreeFactory.Count}");

// Proxy demo
Console.WriteLine();
Console.WriteLine("Proxy pattern demo:");
IImage img = new ProxyImage("photo.jpg");
img.Display(); // loads and displays
img.Display(); // reuses loaded image

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
