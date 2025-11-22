namespace DesignPatterns.AbstractFactory;

public static class FactoryProducer
{
    public enum Style { Modern, Victorian }

    public static IFurnitureFactory GetFactory(Style style) => style switch
    {
        Style.Modern => new ModernFurnitureFactory(),
        Style.Victorian => new VictorianFurnitureFactory(),
        _ => throw new ArgumentException("Unknown style", nameof(style))
    };
}
