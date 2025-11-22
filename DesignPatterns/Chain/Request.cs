namespace DesignPatterns.Chain;

public sealed class Request
{
    public int Level { get; }
    public string Message { get; }

    public Request(int level, string message)
    {
        Level = level;
        Message = message ?? string.Empty;
    }
}
