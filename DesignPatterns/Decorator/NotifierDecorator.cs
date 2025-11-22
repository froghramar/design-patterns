namespace DesignPatterns.Decorator;

public abstract class NotifierDecorator : INotifier
{
    protected readonly INotifier _wrappee;

    protected NotifierDecorator(INotifier wrappee)
    {
        _wrappee = wrappee ?? throw new ArgumentNullException(nameof(wrappee));
    }

    public virtual string Notify(string message) => _wrappee.Notify(message);
}
