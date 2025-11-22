namespace DesignPatterns.Observer;

public class NewsSubscriber : IObserver
{
    public string Name { get; }
    private readonly List<string> _received = new();

    public NewsSubscriber(string name) => Name = name ?? string.Empty;

    public IReadOnlyList<string> Received => _received;

    public void Update(object? sender, object? data)
    {
        _received.Add(data?.ToString() ?? string.Empty);
    }
}
