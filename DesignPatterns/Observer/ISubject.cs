namespace DesignPatterns.Observer;

public interface ISubject
{
    void Attach(IObserver o);
    void Detach(IObserver o);
    void Notify(object? data);
}
