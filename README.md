Design Patterns Examples

A concise introduction

Design patterns provide proven solutions to common software design problems. They describe flexible, reusable approaches to structure classes and objects, improve code maintainability, and communicate design intent. This repository contains small, focused C# examples that demonstrate each pattern and how it can be used in practical code.

Projects
- `DesignPatterns` - Console demo showing multiple design patterns with minimal examples.
- `Tests` - xUnit tests covering the examples.

Pattern examples grouped by category

Creational patterns
- Factory
  - Purpose: Encapsulates object creation and returns different concrete implementations via a common interface.
  - Example: `DesignPatterns/Factories/ShapeFactory.cs`
  - Usage:
    ```csharp
    IShape s = ShapeFactory.CreateShape(ShapeType.Circle, 3.5);
    Console.WriteLine(s.Draw());
    ```

- Singleton
  - Purpose: Ensures a class has only one instance and provides a global point of access.
  - Example: `DesignPatterns/Singleton/Logger.cs`
  - Usage:
    ```csharp
    var logger = Logger.Instance;
    logger.Clear();
    logger.Log("Started");
    foreach (var m in Logger.Instance.Messages) Console.WriteLine(m);
    ```

- Builder
  - Purpose: Separates construction of a complex object from its representation, providing a fluent API.
  - Example: `DesignPatterns/Builder/HouseBuilder.cs` and `DesignPatterns/Builder/House.cs`
  - Usage:
    ```csharp
    var house = new HouseBuilder()
        .WithRooms(3)
        .WithWindows(5)
        .WithGarage()
        .AtAddress("123 Main St")
        .Build();
    Console.WriteLine(house);
    ```

- Prototype
  - Purpose: Create new objects by copying existing ones (useful for deep copies).
  - Example: `DesignPatterns/Prototype/Person.cs` and `DesignPatterns/Prototype/Address.cs`
  - Usage:
    ```csharp
    var p = new Person("Alice", 30, new Address("1 A St", "Townsville"));
    var clone = p.Clone();
    clone.Address.Street = "2 B Ave"; // original unaffected
    ```

- Abstract Factory
  - Purpose: Provide an interface for creating families of related objects without specifying concrete classes.
  - Example: `DesignPatterns/AbstractFactory/*`
  - Usage:
    ```csharp
    var f = FactoryProducer.GetFactory(FactoryProducer.Style.Modern);
    Console.WriteLine(f.CreateChair().Sit());
    ```

Structural patterns
- Adapter
  - Purpose: Convert the interface of a class into another interface clients expect.
  - Example: `DesignPatterns/Adapter/*`
  - Usage:
    ```csharp
    var legacy = new LegacyTextService();
    ITextProvider p = new LegacyTextAdapter(legacy);
    Console.WriteLine(p.GetText());
    ```

- Bridge
  - Purpose: Decouple an abstraction from its implementation so they can vary independently.
  - Example: `DesignPatterns/Bridge/*`
  - Usage:
    ```csharp
    var tv = new Tv();
    var remote = new RemoteControl(tv);
    remote.TogglePower();
    Console.WriteLine(tv.IsEnabled);
    ```

- Composite
  - Purpose: Compose objects into tree structures to represent part–whole hierarchies.
  - Example: `DesignPatterns/Composite/*`
  - Usage:
    ```csharp
    var root = new CompositeGraphic();
    root.Add(new Dot());
    root.Add(new CircleGraphic());
    Console.WriteLine(root.Draw());
    ```

- Decorator
  - Purpose: Attach additional responsibilities to an object dynamically.
  - Example: `DesignPatterns/Decorator/*`
  - Usage:
    ```csharp
    INotifier n = new EmailNotifier();
    n = new SmsDecorator(n);
    Console.WriteLine(n.Notify("Hi"));
    ```

- Facade
  - Purpose: Provide a simplified interface to a complex subsystem.
  - Example: `DesignPatterns/Facade/*`
  - Usage:
    ```csharp
    var facade = new OrderFacade();
    facade.PlaceOrder("Bob", "Widget", 1, "Addr", 9.99m, out var confirmation);
    ```

- Flyweight
  - Purpose: Use sharing to support large numbers of fine-grained objects efficiently.
  - Example: `DesignPatterns/Flyweight/*`
  - Usage:
    ```csharp
    var t = TreeFactory.GetTreeType("Oak", "Green", "Rough");
    var tree = new Tree(10, 20, t);
    Console.WriteLine(tree.Draw());
    ```

- Proxy
  - Purpose: Provide a surrogate or placeholder for another object to control access to it.
  - Example: `DesignPatterns/Proxy/*`
  - Usage:
    ```csharp
    IImage img = new ProxyImage("photo.jpg");
    img.Display();
    ```

Behavioral patterns
- Chain of Responsibility
  - Purpose: Pass a request along a chain of handlers until one handles it.
  - Example: `DesignPatterns/Chain/*`
  - Usage:
    ```csharp
    var h1 = new LevelOneHandler();
    h1.SetNext(new LevelTwoHandler()).SetNext(new DefaultHandler());
    Console.WriteLine(h1.Handle(new Request(2, "req")));
    ```

- Command
  - Purpose: Encapsulate a request as an object to parameterize clients and support undo.
  - Example: `DesignPatterns/Command/*`
  - Usage:
    ```csharp
    var light = new DesignPatterns.Command.Light();
    var on = new DesignPatterns.Command.LightOnCommand(light);
    var r = new DesignPatterns.Command.RemoteControl();
    r.SetCommand(on); r.PressButton();
    ```

- Iterator
  - Purpose: Provide a way to access elements of an aggregate sequentially without exposing its structure.
  - Example: `DesignPatterns/Iterator/*`
  - Usage:
    ```csharp
    var books = new BookCollection();
    books.Add(new Book("Title1", "Author1"));
    books.Add(new Book("Title2", "Author2"));
    var it = books.CreateIterator();
    while (it.HasNext()) Console.WriteLine(it.Next());
    ```

- Mediator
  - Purpose: Encapsulate how a set of objects interact to reduce direct dependencies.
  - Example: `DesignPatterns/Mediator/*`
  - Usage:
    ```csharp
    var room = new ChatRoom();
    var a = new Participant("A");
    var b = new Participant("B");
    room.Register(a); room.Register(b);
    a.Send("hello");
    ```

- Observer
  - Purpose: Define a one-to-many dependency so observers are notified when a subject changes.
  - Example: `DesignPatterns/Observer/*`
  - Usage:
    ```csharp
    var pub = new NewsPublisher();
    var s = new NewsSubscriber("S");
    pub.Attach(s); pub.Notify("news");
    ```

- State
  - Purpose: Allow an object to alter its behavior when its internal state changes.
  - Example: `DesignPatterns/State/*`
  - Usage:
    ```csharp
    var doc = new Document("Initial");
    doc.Edit("content"); doc.Publish();
    ```

- Strategy
  - Purpose: Define a family of algorithms and make them interchangeable.
  - Example: `DesignPatterns/Strategy/*`
  - Usage:
    ```csharp
    var sorter = new Sorter(new BubbleSortStrategy());
    var sorted = sorter.Sort(data);
    sorter.SetStrategy(new QuickSortStrategy());
    sorted = sorter.Sort(data);
    ```

- Template Method
  - Purpose: Define the skeleton of an algorithm in a base class and let subclasses override steps.
  - Example: `DesignPatterns/TemplateMethod/*`
  - Usage:
    ```csharp
    var r = new SalesReport(); Console.WriteLine(r.GenerateReport());
    ```

- Memento
  - Purpose: Capture and externalize an object's internal state so it can be restored later.
  - Example: `DesignPatterns/Memento/*`
  - Usage:
    ```csharp
    var editor = new TextEditor(); var c = new CareTaker();
    editor.Type("Hi"); c.SaveState(editor.Save());
    ```

- Visitor
  - Purpose: Define a new operation without changing the classes of the elements on which it operates.
  - Example: `DesignPatterns/Visitor/*`
  - Usage:
    ```csharp
    var s = new ObjectStructure(); s.Add(new ElementA("a"));
    var v = new ConcreteVisitor(); s.Accept(v); Console.WriteLine(string.Join("\n", v.Log));
    ```

Quick start
- Build solution: `dotnet build`
- Run console demo: `dotnet run --project DesignPatterns`
- Run tests: `dotnet test`

Tests
- Tests are written with xUnit in the `Tests` project and cover the pattern examples (e.g., `Tests/VisitorTests.cs`).

Notes
- The examples are intentionally small for learning and demonstration.
- Projects target .NET 10 / C# 14.
