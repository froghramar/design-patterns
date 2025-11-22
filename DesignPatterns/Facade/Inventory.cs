namespace DesignPatterns.Facade;

internal class Inventory
{
    private readonly Dictionary<string,int> _stock = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Widget"] = 10,
        ["Gadget"] = 5
    };

    public bool HasStock(string product, int quantity)
    {
        if (product is null) return false;
        return _stock.TryGetValue(product, out var available) && available >= quantity;
    }

    public bool Reserve(string product, int quantity)
    {
        if (!HasStock(product, quantity)) return false;
        _stock[product] -= quantity;
        return true;
    }
}
