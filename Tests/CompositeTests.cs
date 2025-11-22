using DesignPatterns.Composite;

namespace Tests;

public class CompositeTests
{
    [Fact]
    public void Composite_DrawsAllChildren()
    {
        var composite = new CompositeGraphic();
        composite.Add(new Dot());
        composite.Add(new CircleGraphic());

        Assert.Equal("Dot, Circle", composite.Draw());
    }

    [Fact]
    public void Composite_CanNestComposites()
    {
        var root = new CompositeGraphic();
        var child = new CompositeGraphic();
        child.Add(new Dot());
        root.Add(child);
        root.Add(new CircleGraphic());

        Assert.Equal("Dot, Circle", root.Draw());
    }
}
