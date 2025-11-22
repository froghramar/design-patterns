namespace DesignPatterns.Chain;

public sealed class LevelOneHandler : Handler
{
    public override string Handle(Request request)
    {
        if (request.Level == 1) return $"LevelOne handled: {request.Message}";
        return base.Handle(request);
    }
}
