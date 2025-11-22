namespace DesignPatterns.Facade;

public sealed class OrderFacade
{
    private readonly Inventory _inventory = new();
    private readonly PaymentProcessor _payment = new();
    private readonly Shipping _shipping = new();

    public bool PlaceOrder(string customer, string product, int quantity, string address, decimal pricePerItem, out string confirmation)
    {
        confirmation = string.Empty;
        if (!_inventory.HasStock(product, quantity)) return false;

        var total = pricePerItem * quantity;
        if (!_payment.Charge(customer, total)) return false;

        if (!_inventory.Reserve(product, quantity)) return false;

        confirmation = _shipping.Ship(product, quantity, address);
        return true;
    }
}
