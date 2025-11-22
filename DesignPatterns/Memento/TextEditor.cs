namespace DesignPatterns.Memento;

public class TextEditor
{
    public string Text { get; private set; } = string.Empty;

    public TextMemento Save() => new TextMemento(Text);

    public void Restore(TextMemento m)
    {
        if (m is null) throw new ArgumentNullException(nameof(m));
        Text = m.State;
    }

    public void Type(string input) => Text += input;
}
