namespace DesignPatterns.Memento;

public class CareTaker
{
    private readonly Stack<TextMemento> _history = new();

    public void SaveState(TextMemento m) => _history.Push(m);

    public TextMemento? PopState() => _history.Count > 0 ? _history.Pop() : null;
}
