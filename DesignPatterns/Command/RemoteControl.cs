namespace DesignPatterns.Command;

public class RemoteControl
{
    private ICommand? _slot;
    private readonly Stack<ICommand> _history = new();

    public void SetCommand(ICommand command) => _slot = command;

    public void PressButton()
    {
        _slot?.Execute();
        if (_slot != null) _history.Push(_slot);
    }

    public void PressUndo()
    {
        if (_history.Any())
        {
            var cmd = _history.Pop();
            cmd.Undo();
        }
    }
}
