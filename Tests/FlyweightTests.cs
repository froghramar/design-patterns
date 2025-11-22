using DesignPatterns.Flyweight;

namespace Tests;

public class FlyweightTests
{
    [Fact]
    public void TreeFactory_ReusesTreeTypes()
    {
        TreeFactory.GetTreeType("Oak", "Green", "Rough");
        TreeFactory.GetTreeType("Oak", "Green", "Rough");
        TreeFactory.GetTreeType("Pine", "DarkGreen", "Smooth");

        Assert.Equal(2, TreeFactory.Count);
    }

    [Fact]
    public void Tree_Draw_IncludesTypeInfo()
    {
        var type = TreeFactory.GetTreeType("Oak", "Green", "Rough");
        var t = new Tree(1, 2, type);
        Assert.Contains("Tree at (1,2)", t.Draw());
        Assert.Contains("Oak", t.Draw());
    }
}
