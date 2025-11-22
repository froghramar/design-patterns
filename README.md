Design Patterns Examples

This solution demonstrates simple design pattern examples in C# targeting .NET 10 (C# 14).

Projects
- `DesignPatterns` - Console demo showing Factory, Singleton, Builder, Prototype, Abstract Factory, Adapter, Bridge, Composite, Decorator, Facade, Flyweight, Proxy, Chain of Responsibility, Command, Iterator, Mediator, and Memento patterns.
  - Factory implementation: `DesignPatterns/Factories`
  - Singleton implementation: `DesignPatterns/Singleton/Logger.cs`
  - Builder implementation: `DesignPatterns/Builder/HouseBuilder.cs` and `DesignPatterns/Builder/House.cs`
  - Prototype implementation: `DesignPatterns/Prototype/Person.cs` and `DesignPatterns/Prototype/Address.cs`
  - Abstract Factory implementation: `DesignPatterns/AbstractFactory/*`
  - Adapter implementation: `DesignPatterns/Adapter/*`
  - Bridge implementation: `DesignPatterns/Bridge/*`
  - Composite implementation: `DesignPatterns/Composite/*`
  - Decorator implementation: `DesignPatterns/Decorator/*`
  - Facade implementation: `DesignPatterns/Facade/*`
  - Flyweight implementation: `DesignPatterns/Flyweight/*`
  - Proxy implementation: `DesignPatterns/Proxy/*`
  - Chain of Responsibility implementation: `DesignPatterns/Chain/*`
  - Command implementation: `DesignPatterns/Command/*`
  - Iterator implementation: `DesignPatterns/Iterator/*`
  - Mediator implementation: `DesignPatterns/Mediator/*`
  - Memento implementation: `DesignPatterns/Memento/*`
- `Tests` - xUnit tests covering the examples.

Included patterns and brief docs

- Factory Pattern
  - Purpose: Encapsulates object creation and returns different concrete implementations via a common interface.
  - Example: `DesignPatterns/Factories/ShapeFactory.cs` creates `Circle`, `Square`, or `Rectangle` based on `ShapeType`.

- Singleton Pattern
  - Purpose: Ensures a class has only one instance and provides a global point of access.
  - Example: `DesignPatterns/Singleton/Logger.cs` — thread-safe singleton using `System.Lazy<T>` and `System.Collections.Concurrent.ConcurrentQueue<string>` to store log messages.
  - Usage snippet:

    ```csharp
    var logger = Logger.Instance;
    logger.Clear();
    logger.Log("Application started");
    foreach (var msg in Logger.Instance.Messages) Console.WriteLine(msg);
    ```

- Builder Pattern
  - Purpose: Separates the construction of a complex object from its representation, providing a fluent API for step-by-step creation.
  - Example: `DesignPatterns/Builder/HouseBuilder.cs` builds immutable `House` instances from `DesignPatterns/Builder/House.cs`.
  - Usage snippet:

    ```csharp
    var house = new HouseBuilder()
        .WithRooms(3)
        .WithWindows(5)
        .WithGarage()
        .AtAddress("123 Main St")
        .Build();
    ```

- Prototype Pattern
  - Purpose: Create new objects by copying existing ones (prototypes), which can be faster or simpler than constructing from scratch. Useful for creating deep copies or variations of an object.
  - Example: `DesignPatterns/Prototype/Person.cs` and `DesignPatterns/Prototype/Address.cs`. `Person.Clone()` returns a deep copy of the `Person` including a cloned `Address`.
  - Usage snippet:

    ```csharp
    var person = new Person("Alice", 30, new Address("1 A St", "Townsville"));
    var clone = person.Clone();
    clone.Address.Street = "2 B Ave"; // does not affect original
    ```

- Abstract Factory Pattern
  - Purpose: Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
  - Example: `DesignPatterns/AbstractFactory/*` contains `IFurnitureFactory`, `ModernFurnitureFactory`, `VictorianFurnitureFactory`, and product interfaces `IChair` and `ISofa`.
  - Usage snippet:

    ```csharp
    var factory = FactoryProducer.GetFactory(FactoryProducer.Style.Modern);
    var chair = factory.CreateChair();
    var sofa = factory.CreateSofa();
    Console.WriteLine(chair.Sit());
    Console.WriteLine(sofa.LieDown());
    ```

- Adapter Pattern
  - Purpose: Convert the interface of a class into another interface clients expect. Allows classes with incompatible interfaces to work together.
  - Example: `DesignPatterns/Adapter/LegacyTextService.cs` is a legacy class exposing `Fetch()`. `DesignPatterns/Adapter/LegacyTextAdapter.cs` adapts it to the `ITextProvider` interface.
  - Usage snippet:

    ```csharp
    var legacy = new LegacyTextService();
    ITextProvider provider = new LegacyTextAdapter(legacy);
    Console.WriteLine(provider.GetText());
    ```

- Bridge Pattern
  - Purpose: Decouple an abstraction from its implementation so the two can vary independently.
  - Example: `DesignPatterns/Bridge/*` provides `IDevice` implementations (`Tv`, `Radio`) and abstractions (`RemoteControl`, `AdvancedRemote`).
  - Usage snippet:

    ```csharp
    var tv = new Tv();
    var remote = new RemoteControl(tv);
    remote.TogglePower();
    remote.VolumeUp();
    remote.SetChannel(10);
    ```

- Composite Pattern
  - Purpose: Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions uniformly.
  - Example: `DesignPatterns/Composite/*` contains `IGraphic` (leaf `Dot`, `CircleGraphic`) and `CompositeGraphic` which aggregates children.
  - Usage snippet:

    ```csharp
    var root = new CompositeGraphic();
    root.Add(new Dot());
    root.Add(new CircleGraphic());
    Console.WriteLine(root.Draw()); // "Dot, Circle"
    ```

- Decorator Pattern
  - Purpose: Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.
  - Example: `DesignPatterns/Decorator/*` contains `INotifier` and concrete decorators `SmsDecorator`, `SlackDecorator` wrapping `EmailNotifier`.
  - Usage snippet:

    ```csharp
    INotifier notifier = new EmailNotifier();
    notifier = new SmsDecorator(notifier);
    notifier = new SlackDecorator(notifier);
    Console.WriteLine(notifier.Notify("Hello"));
    ```

- Facade Pattern
  - Purpose: Provide a simplified interface to a complex subsystem.
  - Example: `DesignPatterns/Facade/*` contains `OrderFacade` which orchestrates `Inventory`, `PaymentProcessor`, and `Shipping` subsystems to place orders.
  - Usage snippet:

    ```csharp
    var facade = new OrderFacade();
    if (facade.PlaceOrder("Bob", "Widget", 2, "1 Road", 9.99m, out var confirmation))
    {
        Console.WriteLine("Order placed: " + confirmation);
    }
    ```

- Flyweight Pattern
  - Purpose: Use sharing to support large numbers of fine-grained objects efficiently by separating intrinsic (shared) from extrinsic (unique) state.
  - Example: `DesignPatterns/Flyweight/*` contains `TreeType`, `TreeFactory`, and `Tree` where `TreeType` is shared and reused by `TreeFactory`.
  - Usage snippet:

    ```csharp
    var t1 = TreeFactory.GetTreeType("Oak", "Green", "Rough");
    var t2 = TreeFactory.GetTreeType("Oak", "Green", "Rough");
    Console.WriteLine(TreeFactory.Count); // 1 or more depending on unique types
    ```

- Proxy Pattern
  - Purpose: Provide a surrogate or placeholder for another object to control access to it.
  - Example: `DesignPatterns/Proxy/*` contains `IImage`, `RealImage`, and `ProxyImage` where `ProxyImage` defers loading of `RealImage` until needed.
  - Usage snippet:

    ```csharp
    IImage img = new ProxyImage("photo.jpg");
    img.Display(); // loads and displays
    img.Display(); // reuses loaded image
    ```

- Chain of Responsibility Pattern
  - Purpose: Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.
  - Example: `DesignPatterns/Chain/*` contains handlers `LevelOneHandler`, `LevelTwoHandler`, and `DefaultHandler` that process requests of different levels.
  - Usage snippet:

    ```csharp
    var h1 = new LevelOneHandler();
    var h2 = new LevelTwoHandler();
    var def = new DefaultHandler();
    h1.SetNext(h2).SetNext(def);
    Console.WriteLine(h1.Handle(new Request(1, "r1")));
    Console.WriteLine(h1.Handle(new Request(2, "r2")));
    Console.WriteLine(h1.Handle(new Request(99, "r3")));
    ```

- Command Pattern
  - Purpose: Encapsulate a request as an object, thereby letting you parameterize clients with queues, requests, and operations and support undoable operations.
  - Example: `DesignPatterns/Command/*` contains `ICommand`, `Light`, `LightOnCommand`, `LightOffCommand`, and `RemoteControl` (invoker).
  - Usage snippet:

    ```csharp
    var light = new Light();
    var on = new LightOnCommand(light);
    var remote = new RemoteControl();
    remote.SetCommand(on);
    remote.PressButton();
    remote.PressUndo();
    ```

- Iterator Pattern
  - Purpose: Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
  - Example: `DesignPatterns/Iterator/*` contains `Book`, `BookCollection`, `BookIterator`, and interfaces `IBookCollection`, `IIterator`.
  - Usage snippet:

    ```csharp
    var books = new BookCollection();
    books.Add(new Book("Title1", "Author1"));
    books.Add(new Book("Title2", "Author2"));
    var it = books.CreateIterator();
    while (it.HasNext()) Console.WriteLine(it.Next());
    ```

- Mediator Pattern
  - Purpose: Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly.
  - Example: `DesignPatterns/Mediator/*` contains `ChatRoom` (mediator) and `Participant` (colleagues) that register with the room and broadcast messages.
  - Usage snippet:

    ```csharp
    var room = new ChatRoom();
    var alice = new Participant("Alice");
    var bob = new Participant("Bob");
    room.Register(alice);
    room.Register(bob);
    alice.Send("Hello Bob");
    ```

- Memento Pattern
  - Purpose: Capture and externalize an object's internal state so it can be restored later without violating encapsulation.
  - Example: `DesignPatterns/Memento/*` contains `TextMemento`, `TextEditor` (originator), and `CareTaker` that stores mementos.
  - Usage snippet:

    ```csharp
    var editor = new TextEditor();
    var caretaker = new CareTaker();
    editor.Type("Hello");
    caretaker.SaveState(editor.Save());
    editor.Type(" World");
    editor.Restore(caretaker.PopState());
    ```

Tests
- Tests are written with xUnit in the `Tests` project.
  - Factory tests: `Tests/ShapeFactoryTests.cs`
  - Singleton tests: `Tests/SingletonTests.cs`
  - Builder tests: `Tests/BuilderTests.cs`
  - Prototype tests: `Tests/PrototypeTests.cs`
  - Abstract Factory tests: `Tests/AbstractFactoryTests.cs`
  - Adapter tests: `Tests/AdapterTests.cs`
  - Bridge tests: `Tests/BridgeTests.cs`
  - Composite tests: `Tests/CompositeTests.cs`
  - Decorator tests: `Tests/DecoratorTests.cs`
  - Facade tests: `Tests/FacadeTests.cs`
  - Flyweight tests: `Tests/FlyweightTests.cs`
  - Proxy tests: `Tests/ProxyTests.cs`
  - Chain tests: `Tests/ChainTests.cs`
  - Command tests: `Tests/CommandTests.cs`
  - Iterator tests: `Tests/IteratorTests.cs`
  - Mediator tests: `Tests/MediatorTests.cs`
  - Memento tests: `Tests/MementoTests.cs`

Common commands
- Build solution: `dotnet build`
- Run console demo: `dotnet run --project DesignPatterns`
- Run tests: `dotnet test`

Notes
- The examples are intentionally small to demonstrate the patterns and are suitable as learning references.
- The `Logger` singleton is implemented to be safe for concurrent use in tests and examples.
