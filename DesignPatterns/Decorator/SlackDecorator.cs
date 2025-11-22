namespace DesignPatterns.Decorator;

public class SlackDecorator : NotifierDecorator
{
    public SlackDecorator(INotifier wrappee) : base(wrappee) { }

    public override string Notify(string message)
    {
        var baseMsg = base.Notify(message);
        return baseMsg + " | Slack: " + message;
    }
}
