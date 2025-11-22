namespace DesignPatterns.Chain;

public sealed class DefaultHandler : Handler
{
    public override string Handle(Request request)
    {
        return $"Default handled: {request.Message}";
    }
}
