using DesignPatterns.Observer;

namespace Tests;

public class ObserverTests
{
    [Fact]
    public void SubscribersReceiveNotifications()
    {
        var publisher = new NewsPublisher();
        var s1 = new NewsSubscriber("A");
        var s2 = new NewsSubscriber("B");

        publisher.Attach(s1);
        publisher.Attach(s2);

        publisher.Notify("Breaking News");

        Assert.Contains("Breaking News", s1.Received);
        Assert.Contains("Breaking News", s2.Received);
    }

    [Fact]
    public void DetachStopsNotifications()
    {
        var publisher = new NewsPublisher();
        var s1 = new NewsSubscriber("A");
        var s2 = new NewsSubscriber("B");

        publisher.Attach(s1);
        publisher.Attach(s2);
        publisher.Detach(s2);

        publisher.Notify("Update");

        Assert.Contains("Update", s1.Received);
        Assert.DoesNotContain("Update", s2.Received);
    }
}
