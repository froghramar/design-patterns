Design Patterns Examples

This solution demonstrates simple design pattern examples in C# targeting .NET 10 (C# 14).

Projects
- `DesignPatterns` - Console demo showing Factory and Singleton patterns.
  - Factory implementation: `DesignPatterns/Factories`
  - Singleton implementation: `DesignPatterns/Singleton/Logger.cs`
- `Tests` - xUnit tests covering the factory and singleton examples.

Requirements
- .NET 10 SDK

Common commands
- Build solution: `dotnet build`
- Run console demo: `dotnet run --project DesignPatterns`
- Run tests: `dotnet test`

Notes
- The `Logger` singleton is thread-safe and uses `System.Lazy<T>` with a `ConcurrentQueue<string>` to store messages.
- Tests are located in the `Tests` project; see `Tests/ShapeFactoryTests.cs` and `Tests/SingletonTests.cs`.
