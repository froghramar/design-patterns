using DesignPatterns.AbstractFactory;

namespace Tests;

public class AbstractFactoryTests
{
    [Fact]
    public void ModernFactory_CreatesModernFurniture()
    {
        var factory = FactoryProducer.GetFactory(FactoryProducer.Style.Modern);
        var chair = factory.CreateChair();
        var sofa = factory.CreateSofa();

        Assert.Equal("Sitting on a modern chair", chair.Sit());
        Assert.Equal("Lying on a modern sofa", sofa.LieDown());
    }

    [Fact]
    public void VictorianFactory_CreatesVictorianFurniture()
    {
        var factory = FactoryProducer.GetFactory(FactoryProducer.Style.Victorian);
        var chair = factory.CreateChair();
        var sofa = factory.CreateSofa();

        Assert.Equal("Sitting on a victorian chair", chair.Sit());
        Assert.Equal("Lying on a victorian sofa", sofa.LieDown());
    }
}
