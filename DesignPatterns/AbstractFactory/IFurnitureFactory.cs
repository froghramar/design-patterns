namespace DesignPatterns.AbstractFactory;

public interface IFurnitureFactory
{
    IChair CreateChair();
    ISofa CreateSofa();
}
