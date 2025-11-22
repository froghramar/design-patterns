namespace DesignPatterns.Observer;

public class NewsPublisher : ISubject
{
    private readonly List<IObserver> _observers = new();

    public void Attach(IObserver o) => _observers.Add(o);

    public void Detach(IObserver o) => _observers.Remove(o);

    public void Notify(object? data)
    {
        foreach (var o in _observers) o.Update(this, data);
    }
}
