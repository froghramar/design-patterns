namespace DesignPatterns.Chain;

public sealed class LevelTwoHandler : Handler
{
    public override string Handle(Request request)
    {
        if (request.Level == 2) return $"LevelTwo handled: {request.Message}";
        return base.Handle(request);
    }
}
