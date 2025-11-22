namespace DesignPatterns.Chain;

public abstract class Handler
{
    protected Handler? Next { get; private set; }

    public Handler SetNext(Handler next)
    {
        Next = next;
        return next;
    }

    public virtual string Handle(Request request)
    {
        if (Next != null) return Next.Handle(request);
        return "Unhandled";
    }
}
