namespace DesignPatterns.Mediator;

public class Participant
{
    public string Name { get; }
    internal ChatRoom? Room { get; set; }

    private readonly List<string> _messages = new();

    public Participant(string name)
    {
        Name = name ?? string.Empty;
    }

    public IReadOnlyList<string> Messages => _messages;

    public void Send(string message)
    {
        if (Room is null) throw new InvalidOperationException("Participant is not registered with a chat room.");
        Room.Broadcast(this, message);
    }

    internal void Receive(string from, string message)
    {
        _messages.Add($"{from}: {message}");
    }
}
