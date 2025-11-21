using System.Collections.Concurrent;

namespace DesignPatterns.Singleton;

public sealed class Logger
{
    private static readonly System.Lazy<Logger> _instance = new(() => new Logger());

    public static Logger Instance => _instance.Value;

    // Use a thread-safe collection to allow concurrent logging in tests
    private readonly ConcurrentQueue<string> _messages = new();

    private Logger() { }

    public IEnumerable<string> Messages => _messages.ToArray();

    public int Count => _messages.Count;

    public void Log(string message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));
        _messages.Enqueue(message);
    }

    public void Clear()
    {
        while (_messages.TryDequeue(out _)) { }
    }
}
