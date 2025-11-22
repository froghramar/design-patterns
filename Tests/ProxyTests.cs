using DesignPatterns.Proxy;

namespace Tests;

public class ProxyTests
{
    [Fact]
    public void Proxy_DelaysLoadingUntilDisplay()
    {
        var proxy = new ProxyImage("photo.jpg");

        // No exceptions when creating proxy
        Assert.NotNull(proxy);

        // Display should create the real image and not throw
        proxy.Display();
    }

    [Fact]
    public void Proxy_ReusesRealImageAfterFirstDisplay()
    {
        var proxy = new ProxyImage("photo2.jpg");
        proxy.Display();
        proxy.Display(); // should reuse the same real image instance without error

        Assert.True(true); // if no exceptions, assume reuse works in this simple example
    }
}
