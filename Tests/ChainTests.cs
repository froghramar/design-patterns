using DesignPatterns.Chain;

namespace Tests;

public class ChainTests
{
    [Fact]
    public void Chain_HandlesLevelOneAndTwoAndDefault()
    {
        var h1 = new LevelOneHandler();
        var h2 = new LevelTwoHandler();
        var def = new DefaultHandler();
        h1.SetNext(h2).SetNext(def);

        var r1 = new Request(1, "r1");
        var r2 = new Request(2, "r2");
        var r3 = new Request(99, "r3");

        Assert.Equal("LevelOne handled: r1", h1.Handle(r1));
        Assert.Equal("LevelTwo handled: r2", h1.Handle(r2));
        Assert.Equal("Default handled: r3", h1.Handle(r3));
    }
}
