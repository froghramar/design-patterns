Design Patterns Examples

This solution demonstrates simple design pattern examples in C# targeting .NET 10 (C# 14).

Projects
- `DesignPatterns` - Console demo showing Factory, Singleton, Builder, Prototype, Abstract Factory, and Adapter patterns.
  - Factory implementation: `DesignPatterns/Factories`
  - Singleton implementation: `DesignPatterns/Singleton/Logger.cs`
  - Builder implementation: `DesignPatterns/Builder/HouseBuilder.cs` and `DesignPatterns/Builder/House.cs`
  - Prototype implementation: `DesignPatterns/Prototype/Person.cs` and `DesignPatterns/Prototype/Address.cs`
  - Abstract Factory implementation: `DesignPatterns/AbstractFactory/*`
  - Adapter implementation: `DesignPatterns/Adapter/*`
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

Tests
- Tests are written with xUnit in the `Tests` project.
  - Factory tests: `Tests/ShapeFactoryTests.cs`
  - Singleton tests: `Tests/SingletonTests.cs`
  - Builder tests: `Tests/BuilderTests.cs`
  - Prototype tests: `Tests/PrototypeTests.cs`
  - Abstract Factory tests: `Tests/AbstractFactoryTests.cs`
  - Adapter tests: `Tests/AdapterTests.cs`

Requirements
- .NET 10 SDK

Common commands
- Build solution: `dotnet build`
- Run console demo: `dotnet run --project DesignPatterns`
- Run tests: `dotnet test`

Notes
- The examples are intentionally small to demonstrate the patterns and are suitable as learning references.
- The `Logger` singleton is implemented to be safe for concurrent use in tests and examples.
