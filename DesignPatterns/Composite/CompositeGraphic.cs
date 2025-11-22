namespace DesignPatterns.Composite;

public sealed class CompositeGraphic : IGraphic
{
    private readonly List<IGraphic> _children = new();

    public void Add(IGraphic g) => _children.Add(g);
    public void Remove(IGraphic g) => _children.Remove(g);

    public string Draw()
    {
        return string.Join(", ", _children.Select(c => c.Draw()));
    }
}
