using DesignPatterns.Visitor;

namespace Tests;

public class VisitorTests
{
    [Fact]
    public void VisitorVisitsAllElements()
    {
        var structure = new ObjectStructure();
        structure.Add(new ElementA("alpha"));
        structure.Add(new ElementB(42));
        structure.Add(new ElementA("beta"));

        var visitor = new ConcreteVisitor();
        structure.Accept(visitor);

        Assert.Equal(3, visitor.Log.Count);
        Assert.Contains("Visited A:alpha", visitor.Log);
        Assert.Contains("Visited B:42", visitor.Log);
        Assert.Contains("Visited A:beta", visitor.Log);
    }
}
