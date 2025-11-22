namespace DesignPatterns.Iterator;

public class BookCollection : IBookCollection
{
    private readonly List<Book> _books = new();

    public void Add(Book book) => _books.Add(book);

    public IIterator CreateIterator() => new BookIterator(_books);
}
