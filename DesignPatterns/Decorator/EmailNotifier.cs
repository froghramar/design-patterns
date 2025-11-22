namespace DesignPatterns.Decorator;

public class EmailNotifier : INotifier
{
    public string Notify(string message) => $"Email: {message}";
}
