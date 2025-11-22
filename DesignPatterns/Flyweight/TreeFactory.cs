namespace DesignPatterns.Flyweight;

public static class TreeFactory
{
    private static readonly Dictionary<string, TreeType> _types = new(StringComparer.OrdinalIgnoreCase);

    public static TreeType GetTreeType(string name, string color, string texture)
    {
        var key = $"{name}:{color}:{texture}";
        if (!_types.TryGetValue(key, out var type))
        {
            type = new TreeType(name, color, texture);
            _types[key] = type;
        }
        return type;
    }

    public static int Count => _types.Count;
}
