namespace DesignPatterns.Decorator;

public class SmsDecorator : NotifierDecorator
{
    public SmsDecorator(INotifier wrappee) : base(wrappee) { }

    public override string Notify(string message)
    {
        var baseMsg = base.Notify(message);
        return baseMsg + " | SMS: " + message;
    }
}
