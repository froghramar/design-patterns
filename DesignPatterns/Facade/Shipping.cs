namespace DesignPatterns.Facade;

internal class Shipping
{
    public string Ship(string product, int quantity, string address)
    {
        return $"Shipped {quantity} x {product} to {address}";
    }
}
