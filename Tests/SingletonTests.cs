using DesignPatterns.Singleton;

namespace Tests;

public class SingletonTests
{
    [Fact]
    public void Logger_IsSingleton()
    {
        var a = Logger.Instance;
        var b = Logger.Instance;

        Assert.Same(a, b);
    }

    [Fact]
    public void Logger_LogsMessages()
    {
        var logger = Logger.Instance;
        logger.Clear();

        logger.Log("first");
        logger.Log("second");

        Assert.Equal(2, logger.Count);
        Assert.Contains("first", logger.Messages);
        Assert.Contains("second", logger.Messages);
    }

    [Fact]
    public void Logger_IsThreadSafe()
    {
        var logger = Logger.Instance;
        logger.Clear();

        var tasks = Enumerable.Range(0, 100).Select(i => Task.Run(() => logger.Log($"m{i}"))).ToArray();
        Task.WaitAll(tasks);

        Assert.Equal(100, logger.Count);
    }
}
