using DesignPatterns.Facade;

namespace Tests;

public class FacadeTests
{
    [Fact]
    public void PlaceOrder_SucceedsWhenStockAndPaymentOk()
    {
        var facade = new OrderFacade();
        var ok = facade.PlaceOrder("Bob", "Widget", 2, "1 Road", 9.99m, out var confirmation);

        Assert.True(ok);
        Assert.Contains("Shipped 2 x Widget to 1 Road", confirmation);
    }

    [Fact]
    public void PlaceOrder_FailsWhenOutOfStock()
    {
        var facade = new OrderFacade();
        var ok = facade.PlaceOrder("Bob", "Widget", 999, "1 Road", 9.99m, out _);

        Assert.False(ok);
    }
}
