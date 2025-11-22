namespace DesignPatterns.Memento;

public sealed class TextMemento
{
    internal string State { get; }

    internal TextMemento(string state)
    {
        State = state ?? string.Empty;
    }
}
