namespace DesignPatterns.Flyweight;

public sealed class TreeType
{
    public string Name { get; }
    public string Color { get; }
    public string Texture { get; }

    public TreeType(string name, string color, string texture)
    {
        Name = name ?? string.Empty;
        Color = color ?? string.Empty;
        Texture = texture ?? string.Empty;
    }

    public override string ToString() => $"{Name} ({Color}, {Texture})";
}
