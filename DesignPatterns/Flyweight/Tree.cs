namespace DesignPatterns.Flyweight;

public sealed class Tree
{
    public int X { get; }
    public int Y { get; }
    public TreeType Type { get; }

    public Tree(int x, int y, TreeType type)
    {
        X = x;
        Y = y;
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }

    public string Draw() => $"Tree at ({X},{Y}) of type {Type}";
}
