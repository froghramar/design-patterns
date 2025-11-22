using DesignPatterns.Iterator;

namespace Tests;

public class IteratorTests
{
    [Fact]
    public void BookIterator_IteratesOverCollection()
    {
        var collection = new BookCollection();
        collection.Add(new Book("Title1", "Author1"));
        collection.Add(new Book("Title2", "Author2"));

        var it = collection.CreateIterator();
        var titles = new List<string>();

        while (it.HasNext())
        {
            titles.Add(it.Next().Title);
        }

        Assert.Equal(new[] { "Title1", "Title2" }, titles);
    }
}
