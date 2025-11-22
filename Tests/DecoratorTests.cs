using DesignPatterns.Decorator;

namespace Tests;

public class DecoratorTests
{
    [Fact]
    public void EmailNotifier_ReturnsEmailMessage()
    {
        INotifier notifier = new EmailNotifier();
        Assert.Equal("Email: Hello", notifier.Notify("Hello"));
    }

    [Fact]
    public void SmsDecorator_AppendsSms()
    {
        INotifier notifier = new SmsDecorator(new EmailNotifier());
        var result = notifier.Notify("Hello");
        Assert.Contains("Email: Hello", result);
        Assert.Contains("SMS: Hello", result);
    }

    [Fact]
    public void MultipleDecorators_ChainCorrectly()
    {
        INotifier notifier = new SlackDecorator(new SmsDecorator(new EmailNotifier()));
        var result = notifier.Notify("Hi");
        Assert.Contains("Email: Hi", result);
        Assert.Contains("SMS: Hi", result);
        Assert.Contains("Slack: Hi", result);
    }
}
