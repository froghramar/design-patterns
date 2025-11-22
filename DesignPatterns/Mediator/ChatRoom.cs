namespace DesignPatterns.Mediator;

public class ChatRoom
{
    private readonly List<Participant> _participants = new();

    public void Register(Participant p)
    {
        if (p is null) throw new ArgumentNullException(nameof(p));
        p.Room = this;
        _participants.Add(p);
    }

    public void Broadcast(Participant from, string message)
    {
        foreach (var p in _participants)
        {
            if (p != from) p.Receive(from.Name, message);
        }
    }
}
